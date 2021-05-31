using Microsoft.AspNetCore.Mvc;

namespace GrandRepairAuto.Web.ViewControllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
