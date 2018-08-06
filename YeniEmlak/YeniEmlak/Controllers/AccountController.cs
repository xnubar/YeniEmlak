using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YeniEmlak.Models.ViewModel;

namespace YeniEmlak.Controllers
{
    //[Authorize]
    public class AccountController : Controller
    {
        private UserManager<UserViewModel> userManager;
        private SignInManager<UserViewModel> signInManager;

        public IActionResult Index()
        {
            var model = new LoginViewModel();

            return View("Login",model);
        }

        //[AllowAnonymous]
        //public ViewResult Login(string returnUrl)
        //{
        //    return View(new LoginViewModel
        //    {
        //        ReturnUrl = returnUrl
        //    });
        //}

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login(LoginViewModel login)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        UserViewModel user =
        //        await userManager.FindByNameAsync(login.Name);
        //        if (user != null)
        //        {
        //            await signInManager.SignOutAsync();
        //            if ((await signInManager.PasswordSignInAsync(user,
        //            login.Password, false, false)).Succeeded)
        //            {
        //                return Redirect(login?.ReturnUrl ?? "/Admin/Index");
        //            }
        //        }
        //    }
        //    ModelState.AddModelError("", "Invalid name or password");
        //    return View(login);
        //}

        //public async Task<RedirectResult> Logout(string returnUrl = "/")
        //{
        //    await signInManager.SignOutAsync();
        //    return Redirect(returnUrl);
        //}


    }
}