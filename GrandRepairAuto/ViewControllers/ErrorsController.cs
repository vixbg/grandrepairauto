using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Models;
using Microsoft.AspNetCore.Authorization;

namespace GrandRepairAuto.Controllers
{
    public class ErrorsController : Controller
    {
        private readonly ILogger<ErrorsController> _logger;

        public ErrorsController(ILogger<ErrorsController> logger)
        {
            _logger = logger;
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
