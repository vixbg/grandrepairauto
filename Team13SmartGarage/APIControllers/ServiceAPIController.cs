using Microsoft.AspNetCore.Mvc;
using Team13SmartGarage.Data.Models;
using Team13SmartGarage.Services;
using Team13SmartGarage.Services.Models.ServiceDTOs;
using Team13SmartGarage.Web.Controllers.API;

namespace Team13SmartGarage.Web.API_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceAPIController : GenericAPIController<Service, int, ServiceDTO, ServiceCreateDTO, ServiceUpdateDTO>
    {
        public ServiceAPIController(GenericService<Service, int, ServiceDTO, ServiceCreateDTO, ServiceUpdateDTO> service) : base(service)
        {

        }
    }
}
