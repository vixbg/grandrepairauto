﻿using AutoMapper;
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
        private readonly IOrderWithCustomerServicesService orderService;
        private readonly IUserService userService;
        private readonly IVehicleService vehicleService;
        private readonly IMapper mapper;

        public OrdersController(IOrderWithCustomerServicesService orderService,  IUserService userService, IVehicleService vehicleService, IMapper mapper)
        {
            this.orderService = orderService;
            this.userService = userService;
            this.vehicleService = vehicleService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<OrderWithCustomerServicesDTO> orders = new List<OrderWithCustomerServicesDTO>();
            
            if (!User.IsInRole("Customer") && (User.IsInRole("Administrator") || User.IsInRole("Employee")))
            {
               orders = orderService.GetAll().ToList();
            }
            else if (User.IsInRole("Customer") && (!User.IsInRole("Administrator") || !User.IsInRole("Employee")))
            { 
                orders = orderService
                    .GetAll()
                    .Where( o=> o.User.Username == User.Identity.Name).ToList();
            }
            else
            {
                orders = orderService.GetAll().ToList();
            }
           
            var ordersVM = mapper.Map<List<OrderVM>>(orders);

            return View(ordersVM);
        }

        [HttpGet]
        public async Task<IActionResult> Details([FromRoute] int Id)
        {
            var order = orderService.GetByID(Id);
            var orderVM = mapper.Map<SingleOrderVM>(order);

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
