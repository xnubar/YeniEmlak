using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YeniEmlak.DomainModel;
using YeniEmlak.Models.ViewModel;

namespace YeniEmlak.Controllers
{
    public class AdminUserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        public AdminUserController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel vm)
        {
            if (vm.NewPassword.Equals(vm.ReNewPassword))
            {            
                var user = (await userManager.FindByIdAsync((UserViewModel.MapUserToUserViewModel
                       ((await (userManager.GetUserAsync(HttpContext.User))))).Id));
                user.PasswordHash = userManager.PasswordHasher.HashPassword(user, vm.NewPassword);
                
                var result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return View("AdminPage");
                }
            }
            throw new Exception("passwords are not the same!");

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await userManager.DeleteAsync(userManager.Users.First(x => x.Id.Equals(id)));
            var users = await userManager.GetUsersInRoleAsync("User");
            var usersVM = users.Select(x => UserViewModel.MapUserToUserViewModel(x));
            return PartialView("Users", usersVM);
        }
        public async Task<IActionResult> GetUsers()
        {
            var users = await userManager.GetUsersInRoleAsync("User");
            var usersVM = users.Select(x => UserViewModel.MapUserToUserViewModel(x));
            return View("UserList", usersVM);
        }

        [HttpGet]
        public async Task<IActionResult> Confirm(string id)
        {
            var user = userManager.Users.First(x => x.Id.Equals(id));
            if (user != null)
            {
                user.SubmittedByAdmin = true;
                await userManager.UpdateAsync(user);

            }
            var users = (await userManager.GetUsersInRoleAsync("User")).Select(x => UserViewModel.MapUserToUserViewModel(x));
            return PartialView("Users", users);
        }

    }
}