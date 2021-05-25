using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Services.Models.VehiclesDTOs;

namespace GrandRepairAuto.Services.Contracts
{
    public interface IVehicleService : IGenericService<Vehicle, int, VehicleDTO, VehicleCreateDTO, VehicleUpdateDTO>
    {
    }
}
