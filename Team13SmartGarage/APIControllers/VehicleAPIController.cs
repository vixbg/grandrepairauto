using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team13SmartGarage.Data.Models;
using Team13SmartGarage.Services;
using Team13SmartGarage.Services.Models.VehiclesDTOs;
using Team13SmartGarage.Web.Controllers.API;

namespace Team13SmartGarage.Web.API_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleAPIController : GenericAPIController<Vehicle, int, VehicleDTO, VehicleDTO, VehicleUpdateDTO>
    {
        public VehicleAPIController(GenericService<Vehicle, int, VehicleDTO, VehicleDTO, VehicleUpdateDTO> service) : base(service)
        {
        }
    }
}
