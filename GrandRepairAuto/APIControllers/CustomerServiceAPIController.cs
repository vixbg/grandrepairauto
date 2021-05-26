using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GrandRepairAuto.Data.Filters;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Services;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Services.Models.CustomerServiceDTOs;

namespace GrandRepairAuto.Web.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerServiceAPIController : GenericAPIController<CustomerService, int, CustomerServiceDTO, CustomerServiceCreateDTO, CustomerServiceUpdateDTO, NoFilter<CustomerService>>
    {
        public CustomerServiceAPIController(ICustomerServiceService service) : base(service)
        {

        }

        [HttpGet("order/{orderId}")]
        public IEnumerable<CustomerServiceDTO> GetByOrder([FromRoute] int orderId)
        {
            return this.service.GetAll(s => s.OrderID == orderId);
        }
    }
}
