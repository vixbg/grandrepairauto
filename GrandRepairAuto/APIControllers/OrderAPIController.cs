using Microsoft.AspNetCore.Mvc;
using GrandRepairAuto.Data.Filters;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Services;
using GrandRepairAuto.Services.Models.OrderDTOs;

namespace GrandRepairAuto.Web.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderAPIController : GenericAPIController<Order, int, OrderDTO, OrderCreateDTO, OrderUpdateDTO, OrderFilter>
    {
        public OrderAPIController(GenericService<Order, int, OrderDTO, OrderCreateDTO, OrderUpdateDTO> service) : base(service)
        {
            
        }
    }
}
