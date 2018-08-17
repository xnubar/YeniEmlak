using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YeniEmlak.Models;
using YeniEmlak.ViewModel;

namespace YeniEmlak.Controllers
{
    public class AdminHomeController : Controller
    {
        private IHomeRepository repository;
        public AdminHomeController(IHomeRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetHomes()
        {
            var homes = repository.GetAll();
            var homesVM = homes.Select(x => HomeViewModel.MapHomeToHomeViewModel(x));
            return View("HomeList", homesVM);
        }

        [HttpGet]
        public IActionResult Confirm(int id)
        {
            var home = repository.FindById(id);
            home.SubmittedByAdmin = true;
            repository.Update(home);
            var homes = repository.GetAll().Select(x => HomeViewModel.MapHomeToHomeViewModel(x));
            return PartialView("Homes", homes);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var home = repository.FindById(id);
            repository.Delete(home);
            var homes = repository.GetAll().Select(x => HomeViewModel.MapHomeToHomeViewModel(x));
            return PartialView("Homes", homes);
        }

    }
}