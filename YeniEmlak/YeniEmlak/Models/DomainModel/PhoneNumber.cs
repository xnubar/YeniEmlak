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
        [ForeignKey("User")]
        public string UserId { get; set; }
        
        public User User { get; set; }
        public string Number { get; set; }

    }
}
