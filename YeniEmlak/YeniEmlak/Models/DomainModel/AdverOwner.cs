using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YeniEmlak.DomainModel;

namespace YeniEmlak.Models.DomainModel
{
    public class AdverOwner
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public virtual ICollection<User> Users { get; set; }
       
    }
}
