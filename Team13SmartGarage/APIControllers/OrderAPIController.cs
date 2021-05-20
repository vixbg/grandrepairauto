using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team13SmartGarage.Data.Models;
using Team13SmartGarage.Services;
using Team13SmartGarage.Services.Models.OrderDTOs;

namespace Team13SmartGarage.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderAPIController : GenericAPIController<Order, int, OrderDTO, OrderDTO, OrderUpdateDTO>
    {
        public OrderAPIController(GenericService<Order, int, OrderDTO, OrderDTO, OrderUpdateDTO> service) : base(service)
        {
            
        }
    }
}
