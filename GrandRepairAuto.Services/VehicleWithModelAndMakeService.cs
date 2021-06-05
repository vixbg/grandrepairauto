using AutoMapper;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Repository.Contracts;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Services.Models.VehiclesDTOs;

namespace GrandRepairAuto.Services
{
    public class VehicleWithModelAndMakeService : GenericService<Vehicle, int, VehicleWithModelAndMakeDTO, VehicleWithModelAndMakeCreateDTO, VehicleWithModelAndMakeUpdateDTO>, IVehicleWithModelAndMakeService
    {
        public VehicleWithModelAndMakeService(IVehicleRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
