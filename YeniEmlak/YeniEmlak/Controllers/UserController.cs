using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace YeniEmlak.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View("AdminPage", "~/Views/Shared/_UserLayout.cshtml");
        }
    }
}