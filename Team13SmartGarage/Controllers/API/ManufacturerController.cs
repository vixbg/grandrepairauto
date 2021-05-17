using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team13SmartGarage.Data.Models;
using Team13SmartGarage.Services;
using Team13SmartGarage.Services.Models.ManufacturerDTOs;

namespace Team13SmartGarage.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : GenericAPIController<Manufacturer, int, ManufacturerDTO,ManufacturerCreateDTO>
    {
        public ManufacturerController(GenericService<Manufacturer, int, ManufacturerDTO, ManufacturerCreateDTO> service) : base(service)
        {
            
        }
    }
}
