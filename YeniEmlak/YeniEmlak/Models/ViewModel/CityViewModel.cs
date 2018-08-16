using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using YeniEmlak.Models.DomainModel;

namespace YeniEmlak.Models.ViewModel
{
    public class CityViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public AreaType AreaType { get; set; }
        public int? ParentId { get; set; }
      
        public static  CityViewModel MapCityToCityViewModel(City vm)
        {
            return new CityViewModel
            {
                Id = vm.Id,
                //AreaType=vm.AreaType,
                //ParentId=vm.ParentId,
                Name = vm.Name
            };
        }
        public static City MapCityViewModelToCity(CityViewModel vm)
        {
          
            return new City
            {
                Id = vm.Id,
               Name=vm.Name
            };
        }
    }
}
