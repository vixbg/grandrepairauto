﻿using AutoMapper;
using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Services.Models.VehiclesDTOs;
using GrandRepairAuto.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrandRepairAuto.Web.ViewControllers
{

    [Authorize(Roles = Roles.AdminsAndEmployees)]
    public class VehiclesController : Controller
    {
        private IVehicleWithModelAndMakeService vehicleService;
        private readonly IVehicleModelService vehicleModelService;
        private readonly IManufacturerService manufacturerService;
        private readonly IUserService userService;
        private IMapper mapper;

        public VehiclesController(
            IVehicleWithModelAndMakeService vehicleService,
            IVehicleModelService vehicleModelService,
            IManufacturerService manufacturerService,
            IUserService userService,
            IMapper mapper)
        {
            this.vehicleService = vehicleService;
            this.vehicleModelService = vehicleModelService;
            this.manufacturerService = manufacturerService;
            this.userService = userService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var vehicles = vehicleService.GetAll();
            var vehiclesVMs = mapper.Map<List<VehicleVM>>(vehicles);
            return View(vehiclesVMs);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Models = vehicleModelService.GetAll().Select(m => mapper.Map<VehicleModelVM>(m));
            ViewBag.Manufacturers = manufacturerService.GetAll().Select(m => mapper.Map<ManufacturerVM>(m));
            ViewBag.Owners = (await userService.GetCustomersAsync()).Select(c => mapper.Map<UserVM>(c));
            return View(new VehicleVM());
        }

        [HttpPost]
        public IActionResult Create(VehicleVM vehicle)
        {
            if (vehicle == null)
            {
                return BadRequest();
            }

            VehicleWithModelAndMakeCreateDTO createDTO = mapper.Map<VehicleWithModelAndMakeCreateDTO>(vehicle);
            vehicleService.Create(createDTO);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var getDTO = vehicleService.GetByID(id);
            if (getDTO == null)
            {
                return NotFound();
            }

            var viewModel = mapper.Map<VehicleVM>(getDTO);
            ViewBag.Owners = (await userService.GetCustomersAsync()).Select(c => mapper.Map<UserVM>(c));

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(VehicleVM vehicle, int id)
        {
            if (vehicle == null)
            {
                return BadRequest();
            }

            VehicleWithModelAndMakeUpdateDTO updateDTO = mapper.Map<VehicleWithModelAndMakeUpdateDTO>(vehicle);
            VehicleWithModelAndMakeDTO updatedVehicleDTO = vehicleService.Update(updateDTO, id);
            if (updatedVehicleDTO == null)
            {
                return BadRequest();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            bool isDeleted = vehicleService.Delete(id);
            if (!isDeleted)
            {
                return BadRequest();
            }

            return RedirectToAction("Index");
        }
    }
}
