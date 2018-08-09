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
    [Authorize]
    public class AdminController : Controller
    {
        private IHomeRepository repository;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        //private readonly IEmailSender emailSender;
        public AdminController(IHomeRepository repo, UserManager<User> userManager,
            SignInManager<User> signInManager)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
            //this.emailSender = emailSender;
            repository = repo;
        }
        public IActionResult Index()
        {
            var model = new LoginViewModel();
            return View("AdminPage", "~/Views/Shared/_AdminLayout.cshtml");

        }
      
        public async Task<IActionResult> Create(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user =UserViewModel.MapUserViewModelToUser( RegisterViewModel.MapRegisterViewModelToUserViewModel(model));

            var result = await this.userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {                

                return View("Index", "~/Views/Shared/_Layout.cshtml");
            }

            return View(model);

        }
    }
}