using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using YeniEmlak.DomainModel;
using YeniEmlak.Models;
using YeniEmlak.Models.ViewModel;
using YeniEmlak.ViewModel;
using System.Web;
using Newtonsoft.Json;

namespace YeniEmlak.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment appEnvironment;
        private IHomeRepository homeRepo;
        List<HomeViewModel> homes;
        int PageSize = 4;
        public static string DependentUI { get; set; }
        public HomeController(IHomeRepository hr, IHostingEnvironment environment)
        {
            homeRepo = hr;
            appEnvironment = environment;

        }
        [HttpGet]
        public JsonResult GetDependentUIs(HomeViewModel home)
        {
            home.dependentUIs = homeRepo.DependentUIs.Select(x => DependentUIViewModel.MapDependentUIToDependentUIViewModel(x)).ToList();
            return Json(home.dependentUIs);
        }

        public IActionResult Index()
        {
            HomesListViewModel model = new HomesListViewModel();
            FilteringParams filterModel = new FilteringParams();
            model.Homes = homeRepo.GetAll().Select(x => HomeViewModel.MapHomeToHomeViewModel(x)).ToList();
            filterModel.Cities = homeRepo.Cities.Select(x => CityViewModel.MapCityToCityViewModel(x)).ToList();
            filterModel.HomeTypes = homeRepo.HomeTypes.Select(x => HomeTypeViewModel.MapHomeTypeToHomeTypeViewModel(x)).ToList();
            filterModel.AdverTypes = homeRepo.AdverTypes.Select(x => AdverTypeViewModel.MapAdverTypeToAdverTypeViewModel(x)).ToList();
            model.FilterParams = filterModel;
            return View("Index", model);
        }
        public IActionResult GetImage(string fileName)
        {
            var imageFileStream = System.IO.File.OpenRead($@"C:\YeniEmlakImages\{fileName}");
            return File(imageFileStream, "image/jpeg");
        }


        #region CRUD
        [HttpPost]
        public IActionResult Create(HomeViewModel home)
        {


            //if (ModelState.IsValid)
            //{
            homeRepo.Create(home);
            return RedirectToAction("Index");
            //}
            //else
            //{
            //    var errors = ModelState.Values.SelectMany(v => v.Errors);
            //}
            // return View("AddHome", home);
        }

        #endregion


        [HttpPost]
        public IActionResult GetSearchResult(HomesListViewModel filtering, int pageNo = 1)
        {
            filtering.Homes = homeRepo.GetByFilterParams(filtering.FilterParams).
                                       Select(x => HomeViewModel.MapHomeToHomeViewModel(x)).
                                       ToList();
            //var homes = HomeList(filtering);
            return PartialView("SearchResult", filtering);
        }

        public HomesListViewModel HomeList(HomesListViewModel homes, int pageNo = 1)
        {
            int totalPage, totalRecord, pageSize;
            pageSize = 5;
            totalRecord = homes.Homes.Count();
            totalPage = (totalRecord / pageSize) + ((totalRecord % pageSize) > 0 ? 1 : 0);
            return (new HomesListViewModel
            {
                Homes = homes.Homes.OrderBy(x => x.Id).
                                                 Skip((pageNo - 1) * PageSize).
                                                   Take(pageSize).ToList(),
                TotalPage = totalPage
            });
        }

        public IActionResult AddHome()
        {
            var home = new HomeViewModel();
            home.Cities = homeRepo.Cities.Select(x => CityViewModel.MapCityToCityViewModel(x)).ToList();
            home.HomeTypes = homeRepo.HomeTypes.Select(x => HomeTypeViewModel.MapHomeTypeToHomeTypeViewModel(x)).ToList();
            home.AdverTypes = homeRepo.AdverTypes.Select(x => AdverTypeViewModel.MapAdverTypeToAdverTypeViewModel(x)).ToList();
            home.dependentUIs = homeRepo.DependentUIs.Select(x => DependentUIViewModel.MapDependentUIToDependentUIViewModel(x)).ToList();
            home.AllEquipments = homeRepo.Equipments.Select(x => EquipmentViewModel.MapEquipmentToEquipmentViewModel(x)).ToList();
            return View("AddHome", home);
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
