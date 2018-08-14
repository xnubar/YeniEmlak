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
    public class UserViewModel : IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        public virtual ICollection<Home> Homes { get; set; }
        public string Address { get; set; }
        public bool SubmittedByAdmin { get; set; }

        public PhoneNumberViewModel UserPhoneNum { get; set; }
        public int? UserPhoneNumId { get; set; }

        [Required]
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public static User MapUserViewModelToUser(UserViewModel vm)
        {
            return new User
            {
                Id = vm.Id,
                FullName = vm.FullName,
                Email = vm.Email,
                // Homes = vm.Homes,
                Address = vm.Address,
                UserPhoneNumId = vm.UserPhoneNumId,
                SubmittedByAdmin = vm.SubmittedByAdmin,
                UserName = vm.UserName
            };

        }
        public static UserViewModel MapUserToUserViewModel(User u)
        {
            return new UserViewModel
            {
                Id = u.Id,
                FullName = u.FullName,
                Address = u.Address,
                Email = u.Email,
                Homes = u.Homes,
                SubmittedByAdmin = u.SubmittedByAdmin,
                UserName = u.UserName,
                UserPhoneNumId = u.UserPhoneNumId,

            };

        }
    }
}
