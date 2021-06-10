using AutoMapper;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Repository.Contracts;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Services.Models.VehicleModelDTOs;

namespace GrandRepairAuto.Services
{
    public class VehicleModelService : GenericService<VehicleModel, int, VehicleModelDTO, VehicleModelCreateDTO, VehicleModelUpdateDTO>, IVehicleModelService
    {
        public VehicleModelService(IVehicleModelRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
