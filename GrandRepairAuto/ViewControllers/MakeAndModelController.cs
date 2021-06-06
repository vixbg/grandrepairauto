using AutoMapper;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Services.Models.ManufacturerDTOs;
using GrandRepairAuto.Services.Models.VehicleModelDTOs;
using GrandRepairAuto.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GrandRepairAuto.Web.ViewControllers
{
    public class MakeAndModelController : Controller
    {
        IManufacturerService manufacturerService;
        IVehicleModelService vehicleModelService;
        IMapper mapper;

        public MakeAndModelController(IManufacturerService manufacturerService, IVehicleModelService vehicleModelService, IMapper mapper)
        {
            this.manufacturerService = manufacturerService;
            this.vehicleModelService = vehicleModelService;
            this.mapper = mapper;
        }

        public IActionResult CreateManufacturer()
        {
            return View(new ManufacturerVM());
        }

        [HttpPost]
        public IActionResult CreateManufacturer(ManufacturerVM manufacturer)
        {
            ManufacturerCreateDTO manufacturerDTO = mapper.Map<ManufacturerCreateDTO>(manufacturer);
            manufacturerService.Create(manufacturerDTO);

            return RedirectToAction("Create", "Vehicles");
        }

        public IActionResult CreateVehicleModel()
        {
            ViewBag.Manufacturers = manufacturerService.GetAll().Select(m => mapper.Map<ManufacturerVM>(m));
            return View(new VehicleModelVM());
        }

        [HttpPost]
        public IActionResult CreateVehicleModel(VehicleModelVM vehicleModel, int manufacturerId)
        {
            VehicleModelCreateDTO vehicleModelDTO = mapper.Map<VehicleModelCreateDTO>(vehicleModel);
            vehicleModelDTO.ManufacturerId = manufacturerId;
            vehicleModelService.Create(vehicleModelDTO);

            return RedirectToAction("Create", "Vehicles");
        }
    }
}
