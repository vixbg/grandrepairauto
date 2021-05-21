﻿using Microsoft.AspNetCore.Mvc;
using GrandRepairAuto.Data.Filters;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Services;
using GrandRepairAuto.Services.Models.ManufacturerDTOs;

namespace GrandRepairAuto.Web.APIControllers
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
