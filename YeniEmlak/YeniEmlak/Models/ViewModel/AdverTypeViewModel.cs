using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using YeniEmlak.DomainModel;

namespace YeniEmlak.Models
{
    public class AdverTypeViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

       
        public static AdverTypeViewModel MapAdverTypeToAdverTypeViewModel(AdverType m)
        {
            return new AdverTypeViewModel
            {
                Id = m.Id,
                Name = m.Name
            };
        }

        public static AdverType MapAdverTypeViewModelToAdverType(AdverTypeViewModel vm)
        {
            return new AdverType
            {
                Id = vm.Id,
                Name = vm.Name
            };
        }
    }
}
