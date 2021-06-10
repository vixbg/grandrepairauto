using Microsoft.AspNetCore.Mvc;

namespace GrandRepairAuto.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
