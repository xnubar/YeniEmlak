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
      
        public virtual ICollection<UserViewModel> Users { get; set; }
        [Required]
        public string NumOne { get; set; }
        public string NumTwo { get; set; }
        public string NumThree{ get; set; }

        public static PhoneNumber MapPhoneNumViewModelToPhoneNum(PhoneNumberViewModel vm)
        {
            return new PhoneNumber
            {
                Id = vm.Id,
                Users = vm.Users.Select(x=>UserViewModel.MapUserViewModelToUser(x)).ToList(),
                NumOne = vm.NumOne,
                NumTwo=vm.NumTwo,
                NumThree=vm.NumThree,

            };
        }
        public static PhoneNumberViewModel MapPhoneNumToPhoneNumViewModel(PhoneNumber pn)
        {
            return new PhoneNumberViewModel
            {
                Id = pn.Id,
                NumOne = pn.NumOne,
                NumTwo=pn.NumTwo,
                NumThree=pn.NumThree,
            };
        }
    }
}
