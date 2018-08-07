using Microsoft.AspNetCore.Identity;
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
    public class UserViewModel:IdentityUser
    {
       
        [Required]
        public string Name { get; set; }
        public virtual AdverOwnerViewModel AdverOwner { get; set; }
        public int? AdverOwnerId { get; set; }
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
                AdverOwnerId=vm.AdverOwnerId,
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
                AdverOwnerId=u.AdverOwnerId,
                AdverOwner = AdverOwnerViewModel.MapAdverOwnerToAdverOwnerViewModel(u.AdverOwner),
                PhoneNumbers = u.PhoneNumbers
            };

        }
    }
}
