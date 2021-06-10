using AutoMapper;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Repository.Contracts;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Services.Models.VehiclesDTOs;

namespace GrandRepairAuto.Services
{
    public class VehicleService : GenericService<Vehicle, int, VehicleDTO, VehicleCreateDTO, VehicleUpdateDTO>, IVehicleService
    {
        public VehicleService(IVehicleRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
