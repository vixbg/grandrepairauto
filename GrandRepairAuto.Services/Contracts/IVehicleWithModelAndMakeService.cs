using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Services.Models.VehiclesDTOs;

namespace GrandRepairAuto.Services.Contracts
{
    public interface IVehicleWithModelAndMakeService : IGenericService<Vehicle, int, VehicleWithModelAndMakeDTO, VehicleWithModelAndMakeCreateDTO, VehicleWithModelAndMakeUpdateDTO>
    {
    }
}
