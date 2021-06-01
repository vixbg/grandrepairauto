using AutoMapper;
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
    public class ServiceController : Controller
    {
        private IServiceService serviceService;
        private IMapper mapper;

        public ServiceController(IServiceService serviceService, IMapper mapper)
        {
            this.serviceService = serviceService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var services = serviceService.GetAll();
            var servicesVMs = mapper.Map<List<ServiceVM>>(services);

            return View(servicesVMs);
        }

        public IActionResult Create()
        {
            return View(new ServiceVM());
        }

        [HttpPost]
        public IActionResult Create(ServiceVM service)
        {
            ServiceCreateDTO createDTO = mapper.Map<ServiceCreateDTO>(service);
            serviceService.Create(createDTO);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var getDTO = serviceService.GetByID(id);
            var viewModel = mapper.Map<ServiceVM>(getDTO);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(ServiceVM service, int id)
        {
            ServiceUpdateDTO updateDTO = mapper.Map<ServiceUpdateDTO>(service);
            serviceService.Update(updateDTO, id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            serviceService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
