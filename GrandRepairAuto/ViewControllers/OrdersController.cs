﻿using AutoMapper;
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
        private readonly IMapper mapper;
        static HttpClient client = new HttpClient();

        public OrdersController(
            IOrderWithCustomerServicesService orderWithCustomerServicesService, 
            IOrderService orderService, 
            IUserService userService, 
            IVehicleService vehicleService, 
            ICustomerServiceService customerServiceService, 
            IServiceService serviceService, 
            IMapper mapper)
        {
            this.orderWithCustomerServicesService = orderWithCustomerServicesService;
            this.orderservice = orderService;
            this.userService = userService;
            this.vehicleService = vehicleService;
            this.customerServiceService = customerServiceService;
            this.serviceService = serviceService;
            this.mapper = mapper;
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


            //HttpResponseMessage response = await client.GetAsync($"https://free.currconv.com/api/v7/convert?apiKey=5d363582e0f1d27c708c&q=BGN_{currency}&compact=ultra");
            //if (response.IsSuccessStatusCode)
            //{
            //    var result = await response.Content.ReadAsAsync<result>();
            //}
            ViewBag.Currencies = new List<string> { "BGN", "USD", "EUR", "PLN" };

            DetailedOrderVM orderVM = mapper.Map<DetailedOrderVM>(order);
            orderVM.Currency = currency;

            // TODO: If Curency != BGN -> Call API for conversion rate
            // Multiply all prices with conversion rate
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
            orderWithCustomerServicesService.Create(createDTO);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update([FromRoute] int id)
        {
            OrderWithCustomerServicesDTO getDTO = orderWithCustomerServicesService.GetByID(id);
            OrderVM viewModel = mapper.Map<OrderVM>(getDTO);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update([FromBody] OrderVM order, [FromRoute] int id)
        {
            OrderUpdateWithCustomerServicesDTO updateDTO = mapper.Map<OrderUpdateWithCustomerServicesDTO>(order);
            orderWithCustomerServicesService.Update(updateDTO, id);

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
        public IActionResult ChangeStatus(int id)
        {
            OrderDTO orderDTO = orderservice.GetByID(id);
            OrderUpdateDTO orderUpdateDTO = mapper.Map<OrderUpdateDTO>(orderDTO);
            orderUpdateDTO.Status = orderDTO.Status + 1;
            orderservice.Update(orderUpdateDTO, id);

            return RedirectToAction("Details", new { id });
        }

        [HttpGet]
        public IActionResult Delete([FromRoute] int id)
        {
            orderWithCustomerServicesService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
