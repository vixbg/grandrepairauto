using AutoMapper;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrandRepairAuto.Web.ViewControllers
{
    [Authorize]
    public class SingleOrderController : Controller
    {
        private IVehicleService vehicleService;
        private readonly IVehicleModelService vehicleModelService;
        private readonly IManufacturerService manufacturerService;
        private readonly IUserService userService;
        private IMapper mapper;
        private readonly ICustomerServiceService customerServiceService;
        private readonly IOrderWithCustomerServicesService orderService;
        private readonly IServiceService serviceService;

        public SingleOrderController(IVehicleService vehicleService, IVehicleModelService vehicleModelService,
            IManufacturerService manufacturerService, IUserService userService, IMapper mapper, ICustomerServiceService customerServiceService, IOrderWithCustomerServicesService orderService, IServiceService serviceService)
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
            var orderVM = mapper.Map<SingleOrderVM>(order);

            return View(orderVM);
        }
    }
}
