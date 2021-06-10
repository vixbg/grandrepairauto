using GrandRepairAuto.Data.Filters;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Services.Models.VehiclesDTOs;
using Microsoft.AspNetCore.Mvc;

namespace GrandRepairAuto.Web.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleAPIController : GenericAPIController<Vehicle, int, VehicleDTO, VehicleCreateDTO, VehicleUpdateDTO, VehicleFilter>
    {
        public VehicleAPIController(IVehicleService service) : base(service)
        {
        }
    }
}
