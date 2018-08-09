using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using YeniEmlak.Models.DomainModel;

namespace YeniEmlak.DomainModel
{
    public class User:IdentityUser
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        [ForeignKey("AdverOwner")]
        public int? AdverOwnerId { get; set; }
        public bool SubmittedByAdmin { get; set; }
        public virtual AdverOwner AdverOwner { get; set; }
        public virtual ICollection<Home> Homes { get; set; }
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }    
    }
}
