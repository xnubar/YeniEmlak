using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YeniEmlak.ViewModel;

namespace YeniEmlak.Models.ViewModel
{
    public class HomesListViewModel
    {
        public FilteringParams FilterParams { get; set; }
        public List<HomeViewModel> Homes { get; set; }
    }
}
