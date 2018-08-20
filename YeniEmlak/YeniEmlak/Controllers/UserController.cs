using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YeniEmlak.DomainModel;
using YeniEmlak.Models.ViewModel;
using YeniEmlak.ViewModel;

namespace YeniEmlak.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        public UserController(UserManager<User> userManager, SignInManager<User> signInManager)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View("UserPage");
        }

        public async Task<IActionResult> UserHomes()
        {
            var user = (await userManager.FindByIdAsync((UserViewModel.MapUserToUserViewModel
                      ((await(userManager.GetUserAsync(HttpContext.User))))).Id));
            HomesListViewModel homes = new HomesListViewModel();
            if (user.Homes.Count>0)
            {
                homes.Homes = user.Homes.Select(x => HomeViewModel.MapHomeToHomeViewModel(x)).ToList();
            }
            else
            {
                homes.Homes = new List<HomeViewModel>();
            }
            return View("UserHomes",homes);
        }

        public async Task<IActionResult> AddEstate()
        {
            var home = new HomeViewModel();
            home.User =UserViewModel.MapUserToUserViewModel((await userManager.FindByIdAsync((UserViewModel.MapUserToUserViewModel
                      ((await(userManager.GetUserAsync(HttpContext.User))))).Id)));
            return View("AddHome",home);
        }
    }
}