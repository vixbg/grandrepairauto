using GrandRepairAuto.Models;
using Microsoft.AspNetCore.Mvc;

namespace GrandRepairAuto.Controllers
{
    public class ErrorsController : Controller
    {
        [Route("/Errors/Status/{code}")]
        public IActionResult Status(int code)
        {
            return View(new ErrorStatusVM(code));
        }
    }
}
