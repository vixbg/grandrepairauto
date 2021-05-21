using Microsoft.AspNetCore.Mvc;
using Team13SmartGarage.Data.Filters;
using Team13SmartGarage.Data.Models;
using Team13SmartGarage.Services;
using Team13SmartGarage.Services.Models.VehiclesDTOs;

namespace Team13SmartGarage.Web.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleAPIController : GenericAPIController<Vehicle, int, VehicleDTO, VehicleDTO, VehicleUpdateDTO, VehicleFilter>
    {
        public VehicleAPIController(GenericService<Vehicle, int, VehicleDTO, VehicleDTO, VehicleUpdateDTO> service) : base(service)
        {
        }
    }
}
