using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GrandRepairAuto.Web.ViewControllers
{

    [Authorize]
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
