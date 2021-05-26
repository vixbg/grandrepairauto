using Microsoft.AspNetCore.Mvc;
using GrandRepairAuto.Data.Filters;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Services;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Services.Models.ServiceDTOs;

namespace GrandRepairAuto.Web.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceAPIController : GenericAPIController<Service, int, ServiceDTO, ServiceCreateDTO, ServiceUpdateDTO, ServiceFilter>
    {
        public ServiceAPIController(IServiceService service) : base(service)
        {

        }
    }
}
