using System;
using AutoMapper;
using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GrandRepairAuto.Services.Models.OrderDTOs;
using GrandRepairAuto.Web.Models;
using Microsoft.EntityFrameworkCore.InMemory.Storage.Internal;

namespace GrandRepairAuto.Web.ViewControllers
{
    [Authorize(Roles = Roles.All)]
    public class SingleOrderController : Controller
    {
        private IVehicleService vehicleService;
        private readonly IVehicleModelService vehicleModelService;
        private readonly IManufacturerService manufacturerService;
        private readonly IUserService userService;
        private IMapper mapper;
        private readonly ICustomerServiceService customerServiceService;
        private readonly IOrderService orderService;
        private readonly IServiceService serviceService;

        public SingleOrderController(IVehicleService vehicleService, IVehicleModelService vehicleModelService,
            IManufacturerService manufacturerService, IUserService userService, IMapper mapper, ICustomerServiceService customerServiceService, IOrderService orderService, IServiceService serviceService)
        {
            this.vehicleService = vehicleService;
            this.vehicleModelService = vehicleModelService;
            this.manufacturerService = manufacturerService;
            this.userService = userService;
            this.mapper = mapper;
            this.customerServiceService = customerServiceService;
            this.orderService = orderService;
            this.serviceService = serviceService;
        }

        public async Task<IActionResult> Index(int id)
        {
            var order = orderService.GetByID(id);
            var owner = (await userService.GetByIDAsync(order.UserId));
            var vehicle = vehicleService.GetByID(order.VehicleId);
            var vehicleModel = vehicleModelService.GetByID(vehicle.VehicleModelId);
            var manufacturer = manufacturerService.GetByID(vehicleModel.ManufacturerId);
            var customerServices = customerServiceService.GetAll(cs => cs.OrderID == order.Id);
            var orderVM = mapper.Map<SingleOrderVM>(order);
            foreach (var cs in customerServices)
            {
                orderVM.CustomerServices.Add(cs);
            }

            orderVM.Owner = owner.FullName;
            orderVM.Email = owner.Email;
            orderVM.PhoneNumber = owner.PhoneNumber;

            orderVM.Manufacturer = manufacturer.Name;
            orderVM.VehicleModel = vehicleModel.Name;
            
            orderVM.RegPlate = vehicle.RegPlate;
            orderVM.Vin = vehicle.Vin;
            orderVM.VehicleType = Enum.GetName(typeof(VehicleTypes), vehicle.VehicleType);
            orderVM.EngineType = Enum.GetName(typeof(EngineTypes), vehicle.EngineType);
            orderVM.Mileage = vehicle.Mileage;
            orderVM.Color = vehicle.Color;
            //orderVM.TotalPrice

            return View(orderVM);
        }
    }
}
