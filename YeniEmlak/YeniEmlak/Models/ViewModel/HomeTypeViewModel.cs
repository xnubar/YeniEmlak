using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using YeniEmlak.DomainModel;

namespace YeniEmlak.ViewModel
{
    public class HomeTypeViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int HomeId { get; set; }
        public ICollection<HomeViewModel> Homes { get; set; }

   
        public static HomeTypeViewModel MapHomeTypeToHomeTypeViewModel(HomeType m)
        {
            return new HomeTypeViewModel
            {
                Id = m.Id,
                Name = m.Name
               // Homes=m.Homes.Select(x=>HomeViewModel.MapHomeToHomeViewModel(x)).ToList()
            };
        }

        public static HomeType MapHomeTypeViewModelToHomeType(HomeTypeViewModel vm)
        {
            return new HomeType
            {
                Id = vm.Id
                //Name = vm.Name
                //Homes=vm.Homes.Select(x=>HomeViewModel.MapHomeViewModelToHome(x)).ToList()
            };
        }
    }
}
