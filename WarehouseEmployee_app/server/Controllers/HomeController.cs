using System;
using Microsoft.AspNetCore.Mvc;

namespace WarehouseEmployee.Controllers
{
    public partial class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
