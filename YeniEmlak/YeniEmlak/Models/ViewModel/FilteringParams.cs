using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YeniEmlak.ViewModel;

namespace YeniEmlak.Models.ViewModel
{
    public class FilteringParams
    {
        public int? HomeTypeId { get; set; }
        public int? CityId { get; set; }
        public int? AdverTypeId { get; set; }
        public decimal? Price1 { get; set; }
        public decimal? Price2 { get; set; }
        public int? Stair1 { get; set; }
        public int? Stair2 { get; set; }
        public int? Area1 { get; set; }
        public int? Area2 { get; set; }

        public int? RoomCount1 { get; set; }
        public int? RoomCount2 { get; set; }
     
       
        public bool? Credit { get; set; }
        public List<AdverTypeViewModel> AdverTypes = new List<AdverTypeViewModel>();
        public List<CityViewModel> Cities = new List<CityViewModel>();
        public List<HomeTypeViewModel> HomeTypes = new List<HomeTypeViewModel>();
    }
}
