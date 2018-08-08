﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YeniEmlak.DomainModel;
using YeniEmlak.Models.ViewModel;

namespace YeniEmlak.Controllers
{
    //[Authorize]
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public IActionResult Index()
        {
            var model = new LoginViewModel();
            return View("Login",model);
        }

        public AccountController(UserManager<User> userMgr,SignInManager<User> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
              
                User user =await userManager.FindByNameAsync(login.Name);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                   if ((await signInManager.PasswordSignInAsync(user,
 login.Password, false, false)).Succeeded)
                    {
                      
                        return RedirectToAction("Index","Admin");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid name or password");
            return View(login);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }


    }
}