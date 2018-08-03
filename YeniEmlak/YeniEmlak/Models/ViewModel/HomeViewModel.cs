using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using YeniEmlak.DomainModel;
using YeniEmlak.Models;
using YeniEmlak.Models.DomainModel;
using YeniEmlak.Models.ViewModel;

namespace YeniEmlak.ViewModel
{
    public class HomeViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; }
        public UserViewModel User { get; set; }
        public EstateDocumentType? EstateDocumentType { get; set; }

        public CityViewModel City { get; set; }
        [Required(ErrorMessage = "Şəhər adını daxil edin.")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Ünvanı daxil edin.")]
        public string Address { get; set; }

        public HomeTypeViewModel HomeType { get; set; }
        [Required(ErrorMessage = "Əmlakın növünü daxil edin.")]
        public int HomeTypeId { get; set; }

        public string HomeImg { get; set; }

        [Required(ErrorMessage = "Əmlakın qiymətini daxil edin.")]
        public decimal Price { get; set; }

        [MaxLength(250), MinLength(20), Required(ErrorMessage = "Əmlak haqqında məlumat daxil edin.")]
        public string AboutHome { get; set; }

        public AdverTypeViewModel AdverType { get; set; }
        [Required(ErrorMessage = "Elanın növünü daxil edin.")]
        public int AdverTypeId { get; set; }

        public BuildingType BuildingType { get; set; }

        public int RoomCount { get; set; }
        public int? Area { get; set; }
        public bool? Credit { get; set; }
        public int? LandArea { get; set; }
        public int? TotalStairCount { get; set; }
        public int? Stair { get; set; }
        public List<EquipmentOfHomeViewModel> Equipments { get; set; }

        [NotMapped, FileExtensions(Extensions = "jpg")]
        public IFormFile Image { set; get; }

        [NotMapped]
        public List<AdverTypeViewModel> AdverTypes = new List<AdverTypeViewModel>();

        [NotMapped]
        public List<CityViewModel> Cities = new List<CityViewModel>();

        [NotMapped]
        public List<DependentUIViewModel> dependentUIs = new List<DependentUIViewModel>();

        [NotMapped]
        public List<HomeTypeViewModel> HomeTypes = new List<HomeTypeViewModel>();

        [NotMapped]
        public List<EquipmentViewModel> AllEquipments = new List<EquipmentViewModel>();

        public static HomeViewModel MapHomeToHomeViewModel(Home home)
        {
            return new HomeViewModel
            {
                Id = home.Id,
                UserId = home.UserId,
                CityId = home.CityId,
                TotalStairCount = home.TotalStairCount,
                Stair = home.Stair,
                BuildingType = home.BuildingType,
                RoomCount = home.RoomCount,
                Area = home.Area,
                Credit = home.Credit,
                LandArea = home.LandArea,
                Address = home.Address,
                HomeTypeId = home.Id,
                HomeImg = home.HomeImg,
                Price = home.Price,
                EstateDocumentType = home.EstateDocumentType,
                AdverTypeId = home.AdverTypeId,
                AboutHome = home.AboutHome,
                City = CityViewModel.MapCityToCityViewModel(home.City),
                User = UserViewModel.MapUserToUserViewModel(home.User),
                HomeType = HomeTypeViewModel.MapHomeTypeToHomeTypeViewModel(home.HomeType),
                AdverType = AdverTypeViewModel.MapAdverTypeToAdverTypeViewModel(home.AdverType)
                //  Equipments = home.Equipments.Select(x => EquipmentOfHomeViewModel.MapEquipmentOfHomeToEquipmentOfHomeViewModel(x)).ToList()

            };
        }

        public static Home MapHomeViewModelToHome(HomeViewModel vm)
        {
            return new Home
            {
                Id = vm.Id,
                UserId = vm.UserId,
                CityId = vm.CityId,
                TotalStairCount = vm.TotalStairCount,
                Stair = vm.Stair,
                Address = vm.Address,
                HomeTypeId = vm.HomeTypeId,
                BuildingType = vm.BuildingType,
                RoomCount = vm.RoomCount,
                Area = vm.Area,
                EstateDocumentType = vm.EstateDocumentType,
                Credit = vm.Credit,
                LandArea = vm.LandArea,
                HomeImg = vm.HomeImg,
                Price = vm.Price,
                AdverTypeId = vm.AdverTypeId,
                AboutHome = vm.AboutHome
                // Equipments = vm.Equipments.Select(x => EquipmentOfHomeViewModel.MapEquipmentOfHomeViewModelToEquipmentOfHome(x)).ToList()
            };
        }
    }
}
