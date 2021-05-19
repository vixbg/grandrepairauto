using Microsoft.AspNetCore.Mvc;
using Team13SmartGarage.Data.Models;
using Team13SmartGarage.Services;
using Team13SmartGarage.Services.Models.CustomerServiceDTOs;
using Team13SmartGarage.Web.Controllers.API;

namespace Team13SmartGarage.Web.API_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerServiceAPIController : GenericAPIController<CustomerService, int, CustomerServiceDTO, CustomerServiceCreateDTO, CustomerServiceUpdateDTO>
    {
        public CustomerServiceAPIController(GenericService<CustomerService, int, CustomerServiceDTO, CustomerServiceCreateDTO, CustomerServiceUpdateDTO> service) : base(service)
        {

        }
    }
}
