using Microsoft.AspNetCore.Mvc;

namespace GrandRepairAuto.Web.ViewControllers
{
    public class VehicleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
