using Microsoft.AspNetCore.Mvc;
using GrandRepairAuto.Data.Filters;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Services;
using GrandRepairAuto.Services.Models.VehicleModelDTOs;

namespace GrandRepairAuto.Web.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleModelAPIController : GenericAPIController<VehicleModel, int, VehicleModelDTO, VehicleModelDTO, VehicleModelDTO, VehicleModelFilter>
    {
        public VehicleModelAPIController(GenericService<VehicleModel, int, VehicleModelDTO, VehicleModelDTO, VehicleModelDTO> service) : base(service)
        {

        }
    }
}
