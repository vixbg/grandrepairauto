using GrandRepairAuto.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GrandRepairAuto.Controllers
{
    public class ErrorsController : Controller
    {
        public ErrorsController()
        {
        }

        public IActionResult Forbidden()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorVM { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
