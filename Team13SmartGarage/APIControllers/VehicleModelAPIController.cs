using Microsoft.AspNetCore.Mvc;
using Team13SmartGarage.Data.Filters;
using Team13SmartGarage.Data.Models;
using Team13SmartGarage.Services;
using Team13SmartGarage.Services.Models.VehicleModelDTOs;

namespace Team13SmartGarage.Web.APIControllers
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
