using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Services.Models.ManufacturerDTOs;

namespace GrandRepairAuto.Services.Contracts
{
    public interface IManufacturerService : IGenericService<Manufacturer, int, ManufacturerDTO, ManufacturerCreateDTO, ManufacturerUpdateDTO>
    {
    }
}
