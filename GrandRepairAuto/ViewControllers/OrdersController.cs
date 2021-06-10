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
using System.Net.Http;
using System.Threading.Tasks;

namespace GrandRepairAuto.Web.ViewControllers
{

    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrderWithCustomerServicesService orderWithCustomerServicesService;
        private readonly IOrderService orderservice;
        private readonly IUserService userService;
        private readonly IVehicleService vehicleService;
        private readonly ICustomerServiceService customerServiceService;
        private readonly IServiceService serviceService;
        private readonly ICurrencyConverter currencyConverter;
        private readonly IMapper mapper;
        private readonly IEmailService emailService;
        static HttpClient client = new HttpClient();

        public OrdersController(
            IOrderWithCustomerServicesService orderWithCustomerServicesService,
            IOrderService orderService,
            IUserService userService,
            IVehicleService vehicleService,
            ICustomerServiceService customerServiceService,
            IServiceService serviceService,
            ICurrencyConverter currencyConverter,
            IMapper mapper,
            IEmailService emailService)
        {
            this.orderWithCustomerServicesService = orderWithCustomerServicesService;
            this.orderservice = orderService;
            this.userService = userService;
            this.vehicleService = vehicleService;
            this.customerServiceService = customerServiceService;
            this.serviceService = serviceService;
            this.currencyConverter = currencyConverter;
            this.mapper = mapper;
            this.emailService = emailService;
        }

        public IActionResult Index()
        {
            var orders = User.IsInRole(Roles.Admin) || User.IsInRole(Roles.Employee)
                ? orderWithCustomerServicesService.GetAll()
                : orderWithCustomerServicesService.GetAll(x => x.User.Email == User.Identity.Name);

            var ordersVM = mapper.Map<List<OrderVM>>(orders);

            return View(ordersVM);
        }

        [HttpGet]
        public async Task<IActionResult> Details([FromRoute] int id, [FromQuery] string currency = "BGN")
        {
            OrderWithCustomerServicesDTO order = orderWithCustomerServicesService.GetByID(id);
            if (order == null)
            {
                return NotFound();
            }

            order.CustomerServices = order.CustomerServices.Where(cs => cs.DeletedOn == null).ToList();

            ViewBag.Currencies = new List<string> { "BGN", "USD", "EUR", "PLN" };

            DetailedOrderVM orderVM = mapper.Map<DetailedOrderVM>(order);
            orderVM.Currency = currency;

            ViewBag.Services = this.serviceService.GetAll(s => s.VehicleType == order.Vehicle.VehicleType).Select(s => mapper.Map<ServiceVM>(s));

            if (currency != "BGN")
            {
                var rate = currencyConverter.GetCurrencyExchange("BGN", currency);
                orderVM.CustomerServices.ForEach(cs => cs.PricePerHour *= rate);
            }

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
            if (order == null)
            {
                return BadRequest();
            }

            OrderCreateWithCustomerServicesDTO createDTO = mapper.Map<OrderCreateWithCustomerServicesDTO>(order);
            orderWithCustomerServicesService.Create(createDTO);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update([FromRoute] int id)
        {
            OrderWithCustomerServicesDTO getDTO = orderWithCustomerServicesService.GetByID(id);
            if (getDTO == null)
            {
                return NotFound();
            }

            OrderVM viewModel = mapper.Map<OrderVM>(getDTO);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update([FromBody] OrderVM order, [FromRoute] int id)
        {
            if (order == null)
            {
                return BadRequest();
            }

            OrderUpdateWithCustomerServicesDTO updateDTO = mapper.Map<OrderUpdateWithCustomerServicesDTO>(order);
            OrderWithCustomerServicesDTO updatedOrderDTO = orderWithCustomerServicesService.Update(updateDTO, id);
            if (updatedOrderDTO == null)
            {
                return BadRequest();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddService(int serviceId, int id)
        {
            var service = this.serviceService.GetByID(serviceId);
            if (service == null)
            {
                return NotFound();
            }

            CustomerServiceCreateDTO customerService = mapper.Map<CustomerServiceCreateDTO>(service);
            customerService.OrderID = id;
            customerService.ServiceId = serviceId;
            this.customerServiceService.Create(customerService);

            return RedirectToAction("Details", new { id });
        }

        [HttpGet]
        public async Task<IActionResult> AdvanceStatus(int id)
        {
            OrderDTO orderDTO = orderservice.GetByID(id);
            if (orderDTO == null)
            {
                return NotFound();
            }

            if (orderDTO.Status >= OrderStatuses.Closed)
            {
                return BadRequest();
            }

            OrderUpdateDTO orderUpdateDTO = mapper.Map<OrderUpdateDTO>(orderDTO);

            orderUpdateDTO.Status = orderDTO.Status + 1;
            OrderDTO updatedOrderDTO = orderservice.Update(orderUpdateDTO, id);
            if (updatedOrderDTO == null)
            {
                BadRequest();
            }

            //if (orderUpdateDTO.Status == OrderStatuses.InProgress)
            //{
            //    OrderWithCustomerServicesDTO order = orderWithCustomerServicesService.GetByID(id);
            //    if (order == null)
            //    {
            //        return NotFound();
            //    }

            //    //await emailService.SendOrderDetailsEmailAsync(User.Identity.Name, User.FindFirst(c => c.Type == "GrandRepair_Names")?.Value, order);
            //}

            return RedirectToAction("Details", new { id });
        }

        [HttpGet]
        public IActionResult RevertStatus(int id)
        {
            OrderDTO orderDTO = orderservice.GetByID(id);
            if (orderDTO == null)
            {
                return NotFound();
            }

            if (orderDTO.Status <= OrderStatuses.New)
            {
                return BadRequest();
            }

            OrderUpdateDTO orderUpdateDTO = mapper.Map<OrderUpdateDTO>(orderDTO);
            orderUpdateDTO.Status = orderDTO.Status - 1;
            OrderDTO updatedOrderDTO = orderservice.Update(orderUpdateDTO, id);
            if (updatedOrderDTO == null)
            {
                return BadRequest();
            }

            return RedirectToAction("Details", new { id });
        }

        [HttpGet]
        public IActionResult RemoveCustomerService(int id, int customerServiceId)
        {
            bool isDeleted = customerServiceService.Delete(customerServiceId);
            if (!isDeleted)
            {
                return BadRequest();
            }

            return RedirectToAction("Details", new { id });
        }

        [HttpGet]
        public IActionResult Delete([FromRoute] int id)
        {
            bool isDeleted = orderWithCustomerServicesService.Delete(id);
            if (!isDeleted)
            {
                return BadRequest();
            }

            return RedirectToAction("Index");
        }
    }
}
