﻿using Microsoft.AspNetCore.Mvc;
using Team13SmartGarage.Data.Filters;
using Team13SmartGarage.Data.Models;
using Team13SmartGarage.Services;
using Team13SmartGarage.Services.Models.ServiceDTOs;

namespace Team13SmartGarage.Web.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceAPIController : GenericAPIController<Service, int, ServiceDTO, ServiceDTO, ServiceDTO, ServiceFilter>
    {
        public ServiceAPIController(GenericService<Service, int, ServiceDTO, ServiceDTO, ServiceDTO> service) : base(service)
        {

        }
    }
}
