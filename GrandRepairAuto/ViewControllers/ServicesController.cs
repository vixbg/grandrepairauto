﻿using AutoMapper;
using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Services.Models.ServiceDTOs;
using GrandRepairAuto.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GrandRepairAuto.Web.ViewControllers
{

    [Authorize(Roles = Roles.AdminsAndEmployees)]
    public class ServicesController : Controller
    {
        private IServiceService serviceService;
        private IMapper mapper;

        public ServicesController(IServiceService serviceService, IMapper mapper)
        {
            this.serviceService = serviceService;
            this.mapper = mapper;
        }

        public IActionResult Index([FromQuery] string currency = "BGN")
        {
            ViewBag.Currencies = new List<string> {"BGN", "USD", "EUR", "PLN"};
            var services = serviceService.GetAll();
            var servicesVMs = mapper.Map<List<ServiceVM>>(services);
            servicesVMs.ForEach(vm => vm.Currency = currency);

            return View(servicesVMs);
        }

        public IActionResult Create()
        {
            return View(new ServiceVM());
        }

        [HttpPost]
        public IActionResult Create(ServiceVM service)
        {
            if (service == null)
            {
                return BadRequest();
            }

            ServiceCreateDTO createDTO = mapper.Map<ServiceCreateDTO>(service);
            serviceService.Create(createDTO);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var getDTO = serviceService.GetByID(id);
            if (getDTO == null)
            {
                return NotFound();
            }

            var viewModel = mapper.Map<ServiceVM>(getDTO);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(ServiceVM service, int id)
        {
            ServiceUpdateDTO updateDTO = mapper.Map<ServiceUpdateDTO>(service);
            ServiceDTO updatedServiceDTO = serviceService.Update(updateDTO, id);
            if (updatedServiceDTO == null)
            {
                return BadRequest();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            bool isDeleted = serviceService.Delete(id);
            if (!isDeleted)
            {
                return BadRequest();
            }

            return RedirectToAction("Index");
        }
    }
}
