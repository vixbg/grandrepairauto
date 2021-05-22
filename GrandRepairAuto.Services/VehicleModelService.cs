using AutoMapper;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Repository;
using GrandRepairAuto.Services.Models.Contracts;
using GrandRepairAuto.Services.Models.VehicleModelDTOs;

namespace GrandRepairAuto.Services
{
    public class VehicleModelService : GenericService<VehicleModel, int, VehicleModelDTO, VehicleModelCreateDTO, VehicleModelDTO>, IVehicleModelService
    {
        public VehicleModelService(GenericRepository<VehicleModel, int> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
