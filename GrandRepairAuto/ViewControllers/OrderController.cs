using AutoMapper;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Services.Models.OrderDTOs;
using GrandRepairAuto.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GrandRepairAuto.Web.ViewControllers
{

    [Authorize]
    public class OrderController : Controller
    {
        private IOrderWithCustomerServicesService orderService;
        private IMapper mapper;

        public OrderController(IOrderWithCustomerServicesService orderService, IMapper mapper)
        {
            this.orderService = orderService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            IEnumerable<OrderWithCustomerServicesDTO> orders = orderService.GetAll();
            List<OrderVM> ordersVM = mapper.Map<List<OrderVM>>(orders);
            return View(ordersVM);
        }

        public IActionResult Create()
        {
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
        public IActionResult Update(int id)
        {
            OrderWithCustomerServicesDTO getDTO = orderService.GetByID(id);
            OrderVM viewModel = mapper.Map<OrderVM>(getDTO);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(OrderVM order, int id)
        {
            OrderUpdateWithCustomerServicesDTO updateDTO = mapper.Map<OrderUpdateWithCustomerServicesDTO>(order);
            orderService.Update(updateDTO, id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            orderService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
