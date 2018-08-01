using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using YeniEmlak.Models.DomainModel;

namespace YeniEmlak.Models.ViewModel
{
    public class EquipmentViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
   

        public static EquipmentViewModel MapEquipmentToEquipmentViewModel(Equipment m)
        {
            return new EquipmentViewModel
            {
                Id = m.Id,
                Name = m.Name
            };
        }



        public static Equipment MapEquipmentViewModelToEquipment(EquipmentViewModel vm)
        {
            return new Equipment
            {
                Id = vm.Id,
                Name = vm.Name
            };
        }
    }
}
