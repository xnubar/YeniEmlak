using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YeniEmlak.DomainModel;

namespace YeniEmlak.Models.DomainModel
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AreaType AreaType { get; set; }
        public int ?ParentId { get; set; }
        public ICollection<Home> Homes { get; set; }
       
    }
}
