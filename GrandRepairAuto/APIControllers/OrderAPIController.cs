using Microsoft.AspNetCore.Mvc;
using GrandRepairAuto.Data.Filters;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Services;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Services.Models.OrderDTOs;
using Microsoft.AspNetCore.Authorization;

namespace GrandRepairAuto.Web.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderAPIController : GenericAPIController<Order, int, OrderDTO, OrderCreateDTO, OrderUpdateDTO, OrderFilter>
    {
        public OrderAPIController(IOrderService service) : base(service)
        {
            
        }
    }
}
