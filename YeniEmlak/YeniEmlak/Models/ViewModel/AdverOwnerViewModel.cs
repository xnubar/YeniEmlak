using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using YeniEmlak.Models.DomainModel;

namespace YeniEmlak.Models.ViewModel
{
   

    public class AdverOwnerViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        public static AdverOwner MapAdverOwnerViewModelToAdverOwner(AdverOwnerViewModel vm)
        {
            return new AdverOwner
            {
                Id = vm.Id,
                Type = vm.Type
            };
        }
        
        public static AdverOwnerViewModel MapAdverOwnerToAdverOwnerViewModel(AdverOwner m)
        {
            return new AdverOwnerViewModel
            {
                Id = m.Id,
                Type = m.Type
            };
        }
    }
}
