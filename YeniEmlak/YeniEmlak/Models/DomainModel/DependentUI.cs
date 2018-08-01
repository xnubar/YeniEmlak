using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YeniEmlak.Models.DomainModel
{
    public class DependentUI
    {
        public int Id { get; set; }
        public string SelectName { get; set; }
        public string ParentName { get; set; }
        public string DivId { get; set; }
    }
}
