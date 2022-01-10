using System;
using Microsoft.AspNetCore.Mvc;

namespace CounterEmployee.Controllers
{
    public partial class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
