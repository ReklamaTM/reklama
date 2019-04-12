using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity.Shared;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Reklama.ViewModels.Filters
{
    public class FiltersViewModel
    {
        public int? CityId { get; set; }
        public string Description { get; set; }
        public int? Rooms { get; set; }
        public int? SquareFrom { get; set; }
        public int? SquareTo { get; set; }
        public int? LevelFrom { get; set; }
        public int? LevelTo { get; set; }
        public bool IsFiltered { get; set; } = false;
        public int DirectionSort { get; set; } = 1;
        public int FieldSort { get; set; } = 1;

        public IEnumerable<City> Cities { get; set; }

        public IEnumerable<Domain.Entity.Realty.Realty> Realties { get; set; }
    }
}
