using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using YeniEmlak.Models.DomainModel;
using YeniEmlak.ViewModel;

namespace YeniEmlak.Models.ViewModel
{
    public class EquipmentOfHomeViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int HomeId { get; set; }
        public int EquipmentId { get; set; }

        public  HomeViewModel Home { get; set; }
        public  EquipmentViewModel Equipment { get; set; }

        public static EquipmentOfHomeViewModel MapEquipmentOfHomeToEquipmentOfHomeViewModel(EquipmentOfHome m)
        {
            return new EquipmentOfHomeViewModel
            {
                Equipment = EquipmentViewModel.MapEquipmentToEquipmentViewModel(m.Equipment),
                EquipmentId = m.EquipmentId,
                Home = HomeViewModel.MapHomeToHomeViewModel(m.Home),
                HomeId = m.HomeId
            };
        }

        public static EquipmentOfHome MapEquipmentOfHomeViewModelToEquipmentOfHome(EquipmentOfHomeViewModel vm)
        {
            return new EquipmentOfHome
            {
                HomeId = vm.HomeId,
                EquipmentId = vm.EquipmentId
                //Equipment = EquipmentViewModel.MapEquipmentViewModelToEquipment(vm.Equipment),
                //Home = HomeViewModel.MapHomeViewModelToHome(vm.Home)
            };
        }
    }
}
