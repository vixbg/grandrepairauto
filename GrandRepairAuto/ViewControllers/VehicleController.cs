using GrandRepairAuto.Data.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GrandRepairAuto.Web.ViewControllers
{

    [Authorize(Roles = Roles.AdminsAndEmployees)]
    public class VehicleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
