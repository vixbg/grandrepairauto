using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Data.Models;
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
        private readonly IVehicleModelService vehicleModelService;
        private readonly IManufacturerService manufacturerService;
        private readonly IUserService userService;
        private IMapper mapper;

        public VehicleController(IVehicleService vehicleService, IVehicleModelService vehicleModelService, 
            IManufacturerService manufacturerService, IUserService userService, IMapper mapper)
        {
            this.vehicleService = vehicleService;
            this.vehicleModelService = vehicleModelService;
            this.manufacturerService = manufacturerService;
            this.userService = userService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            
            var vehicles = vehicleService.GetAll();
            var ownerIds = vehicles.Select(v => v.OwnerId).ToList();
            var owners = (await userService.GetAllAsync()).Where(u => ownerIds.Contains(u.Id));
            var modelIds = vehicles.Select(v => v.VehicleModelId).ToList();
            var models = vehicleModelService.GetAll(m => modelIds.Contains(m.Id));
            var manufacturerIds = models.Select(m => m.ManufacturerId).ToList();
            var manufactures = manufacturerService.GetAll(m => manufacturerIds.Contains(m.Id));
            var modelsToManufacturers = models.ToDictionary(m => m.Id, m => m.ManufacturerId);
            var vehiclesVMs = mapper.Map<List<VehicleVM>>(vehicles);
            vehiclesVMs.ForEach(m =>
            {
                m.VehicleModel = models.First(vm => vm.Id == m.VehicleModelId).Name;
                m.Manufacturer = manufactures.First(mn => mn.Id == modelsToManufacturers[m.VehicleModelId]).Name;
                m.Owner = owners.First(o => o.Id == m.OwnerId).FullName;
            });
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
