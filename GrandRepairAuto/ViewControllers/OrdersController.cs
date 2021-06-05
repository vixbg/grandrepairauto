using AutoMapper;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Services.Models.OrderDTOs;
using GrandRepairAuto.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrandRepairAuto.Web.ViewControllers
{

    [Authorize]
    public class OrdersController : Controller
    {
        private IOrderWithCustomerServicesService orderService;
        private readonly IVehicleModelService vehicleModelService;
        private readonly IManufacturerService manufacturerService;
        private readonly ICustomerServiceService customerServiceService;
        private IUserService userService;
        private IVehicleService vehicleService;
        private IMapper mapper;
        private readonly IServiceService serviceService;

        public OrdersController(IOrderWithCustomerServicesService orderService,IVehicleModelService vehicleModelService, IManufacturerService manufacturerService, ICustomerServiceService customerServiceService,   IUserService userService, IVehicleService vehicleService, IMapper mapper, IServiceService serviceService)
        {
            this.orderService = orderService;
            this.vehicleModelService = vehicleModelService;
            this.manufacturerService = manufacturerService;
            this.customerServiceService = customerServiceService;
            this.userService = userService;
            this.vehicleService = vehicleService;
            this.mapper = mapper;
            this.serviceService = serviceService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<OrderWithCustomerServicesDTO> orders = orderService.GetAll();
            var usersId = orders.Select(o => o.UserId).ToList();
            var users = (await userService.GetAllAsync()).Where(u => usersId.Contains(u.Id));
            var vehiclesIds = orders.Select(o => o.VehicleId).ToList();
            var vehicles = vehicleService.GetAll(v => vehiclesIds.Contains(v.Id));
                        
            List<OrderVM> ordersVM = mapper.Map<List<OrderVM>>(orders);

            ordersVM.ForEach(o =>
            {
                o.User = users.First(u => u.Id == o.UserId).FullName;
                o.Vehicle = vehicles.First(v => v.Id == o.VehicleId).RegPlate;
            });

            return View(ordersVM);
        }

        [HttpGet]
        public async Task<IActionResult> Details([FromRoute] int Id)
        {
            var order = orderService.GetByID(Id);
            var owner = (await userService.GetByIDAsync(order.UserId));
            var vehicle = vehicleService.GetByID(order.VehicleId);
            var vehicleModel = vehicleModelService.GetByID(vehicle.VehicleModelId);
            var manufacturer = manufacturerService.GetByID(vehicleModel.ManufacturerId);
            var customerServices = customerServiceService.GetAll(cs => cs.OrderID == order.Id);
            var customerServicesVM = mapper.Map<List<CustomerServiceVM>>(customerServices);
            var orderVM = mapper.Map<SingleOrderVM>(order);
            foreach (var cs in customerServicesVM)
            {
                orderVM.CustomerServices.Add(cs);
            }

            orderVM.User = mapper.Map<UserVM>(owner);
            orderVM.VehicleModel = mapper.Map<VehicleModelVM>(vehicleModel);
            orderVM.Vehicle = mapper.Map<VehicleVM>(vehicle);
            orderVM.Manufacturer = mapper.Map<ManufacturerVM>(manufacturer);
            return View(orderVM);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Users = (await userService.GetAllAsync()).Select(u => mapper.Map<UserVM>(u));
            ViewBag.Vehicles = vehicleService.GetAll().Select(m => mapper.Map<VehicleVM>(m));
            return View(new OrderVM());
        }

        [HttpPost]
        public IActionResult Create(OrderVM order)
        {
            OrderCreateWithCustomerServicesDTO createDTO = mapper.Map<OrderCreateWithCustomerServicesDTO>(order);
            orderService.Create(createDTO);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update([FromRoute] int id)
        {
            OrderWithCustomerServicesDTO getDTO = orderService.GetByID(id);
            OrderVM viewModel = mapper.Map<OrderVM>(getDTO);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update([FromBody] OrderVM order, [FromRoute] int id)
        {
            OrderUpdateWithCustomerServicesDTO updateDTO = mapper.Map<OrderUpdateWithCustomerServicesDTO>(order);
            orderService.Update(updateDTO, id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete([FromRoute] int id)
        {
            orderService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
