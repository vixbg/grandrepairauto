using Microsoft.AspNetCore.Mvc;
using Team13SmartGarage.Data.Models;
using Team13SmartGarage.Services;
using Team13SmartGarage.Services.Models.VehicleModelDTOs;
using Team13SmartGarage.Web.Controllers.API;

namespace Team13SmartGarage.Web.API_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleModelAPIController : GenericAPIController<VehicleModel, int, VehicleModelDTO, VehicleModelCreateDTO, VehicleModelUpdateDTO>
    {
        public VehicleModelAPIController(GenericService<VehicleModel, int, VehicleModelDTO, VehicleModelCreateDTO, VehicleModelUpdateDTO> service) : base(service)
        {

        }
    }
}
