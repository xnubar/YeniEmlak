using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using YeniEmlak.DomainModel;

namespace YeniEmlak.Models.ViewModel
{
    public class PhoneNumberViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; }
        [Required]
        public UserViewModel User { get; set; }
        [Required]
        public string Number { get; set; }

        public static PhoneNumber MapPhoneNumViewModelToPhoneNum(PhoneNumberViewModel vm)
        {
            return new PhoneNumber
            {
                Id = vm.Id,
                UserId = vm.UserId,
                Number = vm.Number,
                User = UserViewModel.MapUserViewModelToUser(vm.User)

            };
        }
        public static PhoneNumberViewModel MapPhoneNumToPhoneNumViewModel(PhoneNumber pn)
        {
            return new PhoneNumberViewModel
            {
                Id = pn.Id,
                UserId = pn.UserId,
                Number = pn.Number,
                User = UserViewModel.MapUserToUserViewModel(pn.User)
            };
        }
    }
}
