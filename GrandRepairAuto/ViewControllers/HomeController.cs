using GrandRepairAuto.Data.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GrandRepairAuto.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = Roles.Admin)]
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
