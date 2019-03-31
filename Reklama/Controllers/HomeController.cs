using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Enums;
using Domain.Repository.Admin;
using Reklama.Data.Entities;
using Reklama.Data.Servises;
using Reklama.Models;
using Domain.Entity.Admin;
using Domain.Repository.Realty;
using Domain.Repository.Announcements;
using Domain.Entity.Announcements;
using Reklama.Models.ViewModels.Announcement;
using PagedList;

namespace Reklama.Controllers
{
    public class HomeController : _BaseController
    {
        private ReklamaContext rc = new ReklamaContext();

        private readonly IPopularProductRepository _popularProductRepository;
        private readonly INewSectionInCatalogRepository _newSectionInCatalogRepository;
        private readonly IPopularSectionInCatalogRepository _popularSectionCatalogRepository;
        private readonly IPopularAnnouncementRepository _popularAnnoucementRepository;
        private readonly IRealtyRepository _realtyRepository;
        private readonly IAnnouncementRepository _announcementRepository;
        private readonly ICategoryRepository _categoryRepository;

        public HomeController(IPopularSectionInCatalogRepository popularSectionInCatalogRepository,
                            IPopularAnnouncementRepository popularAnnoucementRepository,
                            INewSectionInCatalogRepository newSectionInCatalogRepository,
                            IPopularProductRepository popularProductRepository,
                            IRealtyRepository realtyRepository,
                            IAnnouncementRepository announcementRepository,
                            ICategoryRepository categoryRepository)
        {
            _popularSectionCatalogRepository = popularSectionInCatalogRepository;
            _popularSectionCatalogRepository.Context = rc;

            _newSectionInCatalogRepository = newSectionInCatalogRepository;
            _newSectionInCatalogRepository.Context = rc;

            _popularProductRepository = popularProductRepository;
            _popularProductRepository.Context = rc;

            ViewBag.Slogan = ProjectConfiguration.Get.AnnouncementConfig.Slogan;
            ViewBag.SelectedSiteCategory = CategorySearch.Announcement;

            _popularAnnoucementRepository = popularAnnoucementRepository;
            _popularAnnoucementRepository.Context = rc;

            _realtyRepository = realtyRepository;
            _realtyRepository.Context = rc;

            _announcementRepository = announcementRepository;
            _announcementRepository.Context = rc;

            _categoryRepository = categoryRepository;
            _categoryRepository.Context = rc;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            //return View();
            var model = _realtyRepository.Read().OrderByDescending(x => x.CreatedAt).Take(4).ToList();
            return IsMobileDevice() ? View("IndexMobile", model) : View("Index");
        }

        public ActionResult IndexMobile()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            var model = _realtyRepository.Read().OrderByDescending(x => x.CreatedAt).Take(4).ToList();
            return View("IndexMobile", model);
        }

        public ActionResult FiltersMobile()
        {
            return View("FiltersMobile");
        }

        [ChildActionOnly]
        public ActionResult PopularSectionsInCatalog()
        {
            var shopService = new ShopsService();
            //var popularSections1 = _popularSectionCatalogRepository.Read().ToList();
            var popularSections = shopService.GetPopularCategories().ToList();
            return View(popularSections);
        }

        [ChildActionOnly]
        public ActionResult NewInCatalog()
        {
            var shopService = new ShopsService();
            //var news = _newSectionInCatalogRepository.Read();
            var news = shopService.GetNewCategories();
            return View(news);
        }

        [ChildActionOnly]
        public ActionResult PopularProducts()
        {
            var shopService = new ShopsService();

            //var products = _popularProductRepository.Read().ToList();
            var products = shopService.GetPopularProducts().ToList();
            if (products.Count() <= 5)
            {
                return View(products);
            }
            else
            {
                var result = new List<Product>();
                for (int i = 0; i < 5; i++)
                {
                    int index = new Random().Next(products.Count());
                    result.Add(products[index]);
                    products.RemoveAt(index);
                }
                return View(result);
            }
        }

        [ChildActionOnly]
        public ActionResult ArticlesAndReviews()
        {
            return View();
        }


        public ActionResult RestrictedAccess()
        {
            return View(Request.UrlReferrer);
        }

        [ChildActionOnly]
        public ActionResult PopularAnnouncement()
        {
            var popularAnnouncements = _popularAnnoucementRepository.Read().ToList();
            List<PopularAnnouncement> result = new List<PopularAnnouncement>();
            if(popularAnnouncements.Count() <= 5)
            {
                result = popularAnnouncements;
            }
            else
            {
                for(int i = 0; i < 5; i++)
                {
                    int index = new Random().Next(popularAnnouncements.Count());
                    result.Add(popularAnnouncements[index]);
                    popularAnnouncements.RemoveAt(index);
                }
            }
            return View(result);
        }

        public ActionResult RealtyBlock()
        {
            var realty = _realtyRepository.Read().OrderByDescending(x => x.CreatedAt).Take(4).ToList();
            return View(realty);

        }

        public ActionResult AnnouncementBlock()
        {
            var query= _announcementRepository.ReadActivesQuery().OrderByDescending(x => x.CreatedAt).Where(x => x.SectionId != 3).Take(4);
            var list = query.ToList();
            return View(list);
            
        }

        public ActionResult AutoBlock(){
            
            var query = _announcementRepository.ReadActivesQuery().OrderByDescending(x => x.CreatedAt).Where(x => x.SectionId == 3).Take(4);
            var auto = query.ToList();
            return View(auto);
        }

        public ActionResult AnnouncementList(FilterParams filterParams = null)
        {
            var popularAnnouncements = _popularAnnoucementRepository.Read();
            List<Announcement> announcements = new List<Announcement>();
            foreach(var popularAnnouncement in popularAnnouncements)
            {
                announcements.Add(popularAnnouncement.Announcement);
            }
            var announcementsToSort = _announcementRepository.Sort(announcements.AsQueryable(), filterParams.SortOrder, filterParams.SortOptions, filterParams.SectionId,
                                     filterParams.SubsectionId, filterParams.CategoryId);
            ViewBag.Categories = _categoryRepository.Read(); 
            ViewBag.FilterParams = filterParams;
            return View("AnnouncementList", announcementsToSort.ToPagedList((filterParams.CurrentPage.HasValue) ? filterParams.CurrentPage.Value : 1, filterParams.PageSize));
        }

    }
}
