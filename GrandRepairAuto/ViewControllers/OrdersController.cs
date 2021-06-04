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
        private IUserService userService;
        private IVehicleService vehicleService;
        private IMapper mapper;

        public OrdersController(IOrderWithCustomerServicesService orderService, IUserService userService, IVehicleService vehicleService, IMapper mapper)
        {
            this.orderService = orderService;
            this.userService = userService;
            this.vehicleService = vehicleService;
            this.mapper = mapper;
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
        public IActionResult Details([FromRoute] int orderId)
        {
            return View();
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
