using GrandRepairAuto.Data.Filters;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Services.Models.VehicleModelDTOs;
using Microsoft.AspNetCore.Mvc;

namespace GrandRepairAuto.Web.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleModelAPIController : GenericAPIController<VehicleModel, int, VehicleModelDTO, VehicleModelCreateDTO, VehicleModelUpdateDTO, VehicleModelFilter>
    {
        public VehicleModelAPIController(IVehicleModelService service) : base(service)
        {

        }
    }
}
