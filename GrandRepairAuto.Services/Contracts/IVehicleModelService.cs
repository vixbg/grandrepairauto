using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Services.Models.VehicleModelDTOs;

namespace GrandRepairAuto.Services.Contracts
{
    public interface IVehicleModelService : IGenericService<VehicleModel, int, VehicleModelDTO, VehicleModelCreateDTO, VehicleModelDTO>
    {
    }
}
