using AutoMapper;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Repository;
using GrandRepairAuto.Services.Models.Contracts;
using GrandRepairAuto.Services.Models.VehiclesDTOs;

namespace GrandRepairAuto.Services
{
    public class VehicleService : GenericService<Vehicle, int, VehicleDTO, VehicleDTO, VehicleUpdateDTO>, IVehicleService
    {
        public VehicleService(GenericRepository<Vehicle, int> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
