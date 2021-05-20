using Microsoft.AspNetCore.Mvc;
using Team13SmartGarage.Data.Filters;
using Team13SmartGarage.Data.Models;
using Team13SmartGarage.Services;
using Team13SmartGarage.Services.Models.OrderDTOs;

namespace Team13SmartGarage.Web.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderAPIController : GenericAPIController<Order, int, OrderDTO, OrderDTO, OrderUpdateDTO, OrderFilter>
    {
        public OrderAPIController(GenericService<Order, int, OrderDTO, OrderDTO, OrderUpdateDTO> service) : base(service)
        {
            // /api/order?vehicle=CA
        }
    }
}
