using Microsoft.AspNetCore.Mvc;

namespace GrandRepairAuto.Web.ViewControllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
