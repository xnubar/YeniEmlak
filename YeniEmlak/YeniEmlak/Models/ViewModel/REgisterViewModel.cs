using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YeniEmlak.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public static UserViewModel MapRegisterViewModelToUserViewModel(RegisterViewModel model)
        {
            return new UserViewModel
            {
                FullName=model.FirstName+" "+model.LastName,
                Email=model.Email,
                Address=model.Address,
                SubmittedByAdmin=false,
                UserName=model.UserName
            };
        }
    }
}
