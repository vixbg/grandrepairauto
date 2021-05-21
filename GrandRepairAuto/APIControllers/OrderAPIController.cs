using Microsoft.AspNetCore.Mvc;
using GrandRepairAuto.Data.Filters;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Services;
using GrandRepairAuto.Services.Models.OrderDTOs;

namespace GrandRepairAuto.Web.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderAPIController : GenericAPIController<Order, int, OrderDTO, OrderDTO, OrderUpdateDTO, OrderFilter>
    {
        public OrderAPIController(GenericService<Order, int, OrderDTO, OrderDTO, OrderUpdateDTO> service) : base(service)
        {
            //TODO: Finish Filter in Controllers
            // /api/order?vehicle=CA


            //TODO: Pagination
        }
    }
}
