using Microsoft.AspNetCore.Mvc;
using Team13SmartGarage.Data.Filters;
using Team13SmartGarage.Data.Models;
using Team13SmartGarage.Services;
using Team13SmartGarage.Services.Models.CustomerServiceDTOs;

namespace Team13SmartGarage.Web.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerServiceAPIController : GenericAPIController<CustomerService, int, CustomerServiceDTO, CustomerServiceCreateDTO, CustomerServiceUpdateDTO, NoFilter<CustomerService>>
    {
        public CustomerServiceAPIController(GenericService<CustomerService, int, CustomerServiceDTO, CustomerServiceCreateDTO, CustomerServiceUpdateDTO> service) : base(service)
        {

        }
    }
}
