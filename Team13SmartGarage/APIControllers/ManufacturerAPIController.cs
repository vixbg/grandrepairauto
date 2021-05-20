﻿using Microsoft.AspNetCore.Http;
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
    public class ManufacturerAPIController : GenericAPIController<Manufacturer, int, ManufacturerDTO, ManufacturerDTO, ManufacturerDTO>
    {
        public ManufacturerAPIController(GenericService<Manufacturer, int, ManufacturerDTO, ManufacturerDTO, ManufacturerDTO> service) : base(service)
        {
            
        }
    }
}
