using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using YeniEmlak.DomainModel;
using YeniEmlak.Models.DomainModel;

namespace YeniEmlak.Models.ViewModel
{
    public class UserViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [RegularExpression(".+\\@.+\\..+",
            ErrorMessage = "Emaili düzgün daxil edin.")]
        public string Email { get; set; }
        public virtual AdverOwnerViewModel AdverOwner { get; set; }
        public virtual ICollection<Home> Homes { get; set; }
        [Required]
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }

        public static User MapUserViewModelToUser(UserViewModel vm)
        {
            return new User
            {
                Id = vm.Id,
                Name = vm.Name,
                Email = vm.Email,
                Homes = vm.Homes,
                AdverOwner=AdverOwnerViewModel.MapAdverOwnerViewModelToAdverOwner(vm.AdverOwner),
                PhoneNumbers = vm.PhoneNumbers
            };

        }
        public static UserViewModel MapUserToUserViewModel(User u)
        {
            return new UserViewModel
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Homes = u.Homes,
                AdverOwner = AdverOwnerViewModel.MapAdverOwnerToAdverOwnerViewModel(u.AdverOwner),
                PhoneNumbers = u.PhoneNumbers
            };

        }
    }
}
