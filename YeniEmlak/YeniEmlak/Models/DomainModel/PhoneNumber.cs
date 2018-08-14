using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YeniEmlak.DomainModel
{
    public class PhoneNumber
    {
        public int Id { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public string NumOne { get; set; }
        public string NumTwo { get; set; }
        public string NumThree { get; set; }

    }
}
