using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YeniEmlak.DomainModel;
using YeniEmlak.Models;
using YeniEmlak.Models.ViewModel;
using YeniEmlak.ViewModel;

namespace YeniEmlak.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private IHomeRepository repository;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        public AdminController(IHomeRepository repo, UserManager<User> userManager,
            SignInManager<User> signInManager)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
            repository = repo;
        }
        public IActionResult Index()
        {
            var model = new LoginViewModel();
            return View("AdminPage", "~/Views/Shared/_AdminLayout.cshtml");
        }

        public async Task<IActionResult> GetUsers()
        {
            var users = await userManager.GetUsersInRoleAsync("User");
            var usersVM = users.Select(x => UserViewModel.MapUserToUserViewModel(x));
            return View("UserList", usersVM);
        }

        public IActionResult GetHomes()
        {
            var homes = repository.GetAll();
            var homesVM = homes.Select(x => HomeViewModel.MapHomeToHomeViewModel(x));
            return View("HomeList", homesVM);
        }

        [HttpGet]
        public async Task<IActionResult> SubmitUser(string id)
        {
            var user = userManager.Users.First(x => x.Id.Equals(id));
            if (user != null)
            {
                user.SubmittedByAdmin = true;
                await userManager.UpdateAsync(user);
            }
            return View();
        }

        [HttpGet]
        public IActionResult SubmitHome(int id)
        {
            var home = repository.FindById(id);
            home.SubmittedByAdmin = true;
            repository.Update(HomeViewModel.MapHomeToHomeViewModel(home));
            return View();
        }




        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await userManager.DeleteAsync(userManager.Users.First(x => x.Id.Equals(id)));
            return RedirectToAction("GetUsers");
        }

        [HttpDelete]
        public IActionResult DeleteHome(int id)
        {
            var home = repository.FindById(id);
            repository.Delete(HomeViewModel.MapHomeToHomeViewModel(home));
            return View();
        }
    }
}