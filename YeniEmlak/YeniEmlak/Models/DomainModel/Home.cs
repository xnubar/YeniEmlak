using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using YeniEmlak.Models;
using YeniEmlak.Models.DomainModel;

namespace YeniEmlak.DomainModel
{
    public class Home
    {   
       
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public EstateDocumentType? EstateDocumentType { get; set; }

        public int? TotalStairCount { get; set; }
        public int? Stair { get; set; }
        [ForeignKey("City")]
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public string Address { get; set; }

        [ForeignKey("HomeType")]
        public virtual int HomeTypeId { get; set; }

        public BuildingType BuildingType { get; set; }
        public HomeType HomeType { get; set; }

        [ForeignKey("AdverType")]
        public int AdverTypeId { get; set; }
        
        public virtual AdverType AdverType { get; set; }
        public List<EquipmentOfHome> Equipments { get; set; }

        public int RoomCount { get; set; }
        public int? Area { get; set; }
        public bool? Credit { get; set; }
        public string HomeImg { get; set; }
        public decimal Price { get; set; }
        public string AboutHome { get; set; }
        public int? LandArea { get; set; }

    }
}
