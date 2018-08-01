using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YeniEmlak.DomainModel;
using YeniEmlak.ViewModel;

namespace YeniEmlak.ViewComponents
{
   // [ViewComponent(Name = "HomeViewComponent")]
    public class HomeViewComponent : ViewComponent
    {

        public List<Home> homes = new List<Home>();
        public async Task<IViewComponentResult> InvokeAsync(HomeViewModel home)
        {
            return View(home);
        }
    }
}
