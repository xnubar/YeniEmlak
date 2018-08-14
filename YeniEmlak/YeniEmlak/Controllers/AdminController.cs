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
            return View("AdminPage","~/Views/Shared/_AdminLayout.cshtml");
        }
        public async Task<IActionResult> GetUsers()
        {
            var users = await userManager.GetUsersInRoleAsync("User");
            var usersVM = users.Select(x=>UserViewModel.MapUserToUserViewModel(x));
            return View("UserList", usersVM);
        }
        public IActionResult ConfirmRequest()
        {
            return View();
        }
    }
}