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
    public class OrderController : GenericAPIController<Order, int, OrderDTO, OrderCreateDTO>
    {
        public OrderController(GenericService<Order, int, OrderDTO, OrderCreateDTO> service) : base(service)
        {
            
        }
    }
}
