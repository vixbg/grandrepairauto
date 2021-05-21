using Microsoft.AspNetCore.Mvc;
using GrandRepairAuto.Data.Filters;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Services;
using GrandRepairAuto.Services.Models.ServiceDTOs;

namespace GrandRepairAuto.Web.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceAPIController : GenericAPIController<Service, int, ServiceDTO, ServiceDTO, ServiceDTO, ServiceFilter>
    {
        public ServiceAPIController(GenericService<Service, int, ServiceDTO, ServiceDTO, ServiceDTO> service) : base(service)
        {

        }
    }
}
