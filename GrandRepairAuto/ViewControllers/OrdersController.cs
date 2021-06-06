using AutoMapper;
using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Services.Models.CustomerServiceDTOs;
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
        private readonly IOrderWithCustomerServicesService orderService;
        private readonly IUserService userService;
        private readonly IVehicleService vehicleService;
        private readonly ICustomerServiceService customerServiceService;
        private readonly IServiceService serviceService;
        private readonly IMapper mapper;

        public OrdersController(IOrderWithCustomerServicesService orderService, IUserService userService, IVehicleService vehicleService, ICustomerServiceService customerServiceService, IServiceService serviceService, IMapper mapper)
        {
            this.orderService = orderService;
            this.userService = userService;
            this.vehicleService = vehicleService;
            this.customerServiceService = customerServiceService;
            this.serviceService = serviceService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var orders = User.IsInRole(Roles.Admin) || User.IsInRole(Roles.Employee)
                ? orderService.GetAll()
                : orderService.GetAll(x => x.User.Email == User.Identity.Name);

            var ordersVM = mapper.Map<List<OrderVM>>(orders);

            return View(ordersVM);
        }

        [HttpGet]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            OrderWithCustomerServicesDTO order = orderService.GetByID(id);
            if (order==null)
            {
                return NotFound();
            }

            DetailedOrderVM orderVM = mapper.Map<DetailedOrderVM>(order);
            ViewBag.Services = this.serviceService.GetAll(s => s.VehicleType == order.Vehicle.VehicleType).Select(s => mapper.Map<ServiceVM>(s));

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

        [HttpPost]
        public IActionResult AddService(int serviceId, int id)
        {            
            CustomerServiceCreateDTO customerService = mapper.Map<CustomerServiceCreateDTO>(this.serviceService.GetByID(serviceId));
            customerService.OrderID = id;
            customerService.ServiceId = serviceId;
            this.customerServiceService.Create(customerService);

            return RedirectToAction("Details", new { id });
        }

        [HttpGet]
        public IActionResult Delete([FromRoute] int id)
        {
            orderService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
