using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using YeniEmlak.Models.DomainModel;

namespace YeniEmlak.Models.ViewModel
{
    public class DependentUIViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string ParentName { get; set; }
        public string SelectName { get; set; }
        public string DivId { get; set; }
        public static DependentUI MapDependentUIViewModelToDependentUI(DependentUIViewModel vm)
        {
            return new DependentUI
            {
                ParentName = vm.ParentName,
                Id = vm.Id,
                DivId=vm.DivId,
                SelectName=vm.SelectName
            };
        }
        public static DependentUIViewModel MapDependentUIToDependentUIViewModel(DependentUI m)
        {
          
            return new DependentUIViewModel
            {
                Id = m.Id,
                ParentName=m.ParentName,
                DivId=m.DivId,
                SelectName=m.SelectName
            };
        }

    }
}
