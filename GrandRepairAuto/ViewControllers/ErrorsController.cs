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


        public IActionResult NotFound()
        {
            return View();
        }
      

    }
}
