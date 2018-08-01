using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YeniEmlak.DomainModel
{
 
    public class HomeType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Home> Homes { get; set; }    
    }
}
