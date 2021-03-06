//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Reklama.Data.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserProfile
    {
        public UserProfile()
        {
            this.Announcement = new HashSet<Announcement>();
            this.AnnouncementBookmarks = new HashSet<AnnouncementBookmarks>();
            this.AnnouncementComments = new HashSet<AnnouncementComments>();
            this.ArticleComment = new HashSet<ArticleComment>();
            this.PrivateMessages = new HashSet<PrivateMessages>();
            this.PrivateMessages1 = new HashSet<PrivateMessages>();
            this.PrivateMessages2 = new HashSet<PrivateMessages>();
            this.ProductBookmark = new HashSet<ProductBookmark>();
            this.ProductFeedback = new HashSet<ProductFeedback>();
            this.Realty = new HashSet<Realty>();
            this.RealtyComment = new HashSet<RealtyComment>();
            this.Shop = new HashSet<Shop>();
            this.ShopComment = new HashSet<ShopComment>();
            this.webpages_Roles = new HashSet<webpages_Roles>();
        }
    
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public string Icq { get; set; }
        public string Phone { get; set; }
        public string AvatarLink { get; set; }
        public string Site { get; set; }
        public string About { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    
        public virtual ICollection<Announcement> Announcement { get; set; }
        public virtual ICollection<AnnouncementBookmarks> AnnouncementBookmarks { get; set; }
        public virtual ICollection<AnnouncementComments> AnnouncementComments { get; set; }
        public virtual ICollection<ArticleComment> ArticleComment { get; set; }
        public virtual ICollection<PrivateMessages> PrivateMessages { get; set; }
        public virtual ICollection<PrivateMessages> PrivateMessages1 { get; set; }
        public virtual ICollection<PrivateMessages> PrivateMessages2 { get; set; }
        public virtual ICollection<ProductBookmark> ProductBookmark { get; set; }
        public virtual ICollection<ProductFeedback> ProductFeedback { get; set; }
        public virtual ICollection<Realty> Realty { get; set; }
        public virtual ICollection<RealtyComment> RealtyComment { get; set; }
        public virtual ICollection<Shop> Shop { get; set; }
        public virtual ICollection<ShopComment> ShopComment { get; set; }
        public virtual ICollection<webpages_Roles> webpages_Roles { get; set; }
    }
}
