using Microsoft.AspNetCore.Mvc;
using GrandRepairAuto.Data.Filters;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Services;
using GrandRepairAuto.Services.Models.VehiclesDTOs;

namespace GrandRepairAuto.Web.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleAPIController : GenericAPIController<Vehicle, int, VehicleDTO, VehicleCreateDTO, VehicleUpdateDTO, VehicleFilter>
    {
        public VehicleAPIController(GenericService<Vehicle, int, VehicleDTO, VehicleCreateDTO, VehicleUpdateDTO> service) : base(service)
        {
        }
    }
}
