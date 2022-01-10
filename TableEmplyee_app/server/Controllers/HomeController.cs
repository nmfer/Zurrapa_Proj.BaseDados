using System;
using Microsoft.AspNetCore.Mvc;

namespace TableEmployee.Controllers
{
    public partial class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
