using Microsoft.AspNetCore.Mvc;
using Team13SmartGarage.Data.Filters;
using Team13SmartGarage.Data.Models;
using Team13SmartGarage.Services;
using Team13SmartGarage.Services.Models.ManufacturerDTOs;

namespace Team13SmartGarage.Web.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerAPIController : GenericAPIController<Manufacturer, int, ManufacturerDTO, ManufacturerDTO, ManufacturerDTO, NoFilter<Manufacturer>>
    {
        public ManufacturerAPIController(GenericService<Manufacturer, int, ManufacturerDTO, ManufacturerDTO, ManufacturerDTO> service) : base(service)
        {

        }
    }
}
