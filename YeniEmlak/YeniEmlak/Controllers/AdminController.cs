using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YeniEmlak.Models;

namespace YeniEmlak.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IHomeRepository repository;
        public AdminController(IHomeRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}