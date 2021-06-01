using GrandRepairAuto.Data.Filters;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Services.Models.ManufacturerDTOs;
using Microsoft.AspNetCore.Mvc;

namespace GrandRepairAuto.Web.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerAPIController : GenericAPIController<Manufacturer, int, ManufacturerDTO, ManufacturerCreateDTO, ManufacturerUpdateDTO, NoFilter<Manufacturer>>
    {
        public ManufacturerAPIController(IManufacturerService service) : base(service)
        {
        }
    }
}
