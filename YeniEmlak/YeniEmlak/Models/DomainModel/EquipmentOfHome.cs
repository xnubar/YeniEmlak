using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using YeniEmlak.DomainModel;

namespace YeniEmlak.Models.DomainModel
{
    public class EquipmentOfHome
    {
     
        public int Id { get; set; }
       
        [ForeignKey("Home")]
        public int HomeId { get; set; }
      
        [ForeignKey("Equipment")]
        public int EquipmentId { get; set; }

        public virtual Home Home { get; set; }
        public virtual Equipment Equipment { get; set; }
    }
}
