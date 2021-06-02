using System.Collections.Generic;
using AutoMapper;
using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Services;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Services.Models.VehiclesDTOs;
using GrandRepairAuto.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GrandRepairAuto.Web.ViewControllers
{

    [Authorize(Roles = Roles.AdminsAndEmployees)]
    public class VehicleController : Controller
    {
        private IVehicleService vehicleService;
        private IMapper mapper;

        public VehicleController(IVehicleService vehicleService, IMapper mapper)
        {
            this.vehicleService = vehicleService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var vehicles = vehicleService.GetAll();
            var vehiclesVMs = mapper.Map<List<VehicleVM>>(vehicles);
            return View(vehiclesVMs);
        }

        public IActionResult Create()
        {
            return View(new VehicleVM());
        }

        [HttpPost]
        public IActionResult Create(VehicleVM vehicle)
        {
            VehicleCreateDTO createDTO = mapper.Map<VehicleCreateDTO>(vehicle);
            vehicleService.Create(createDTO);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var getDTO = vehicleService.GetByID(id);
            var viewModel = mapper.Map<VehicleVM>(getDTO);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(VehicleVM vehicle, int id)
        {
            VehicleUpdateDTO updateDTO = mapper.Map<VehicleUpdateDTO>(vehicle);
            vehicleService.Update(updateDTO, id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            vehicleService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
