using GrandRepairAuto.Data.Filters;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Services.Models.OrderDTOs;
using Microsoft.AspNetCore.Mvc;

namespace GrandRepairAuto.Web.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderAPIController : GenericAPIController<Order, int, OrderDTO, OrderCreateDTO, OrderUpdateDTO, OrderFilter>
    {
        public OrderAPIController(IOrderService service) : base(service)
        {

        }
    }
}
