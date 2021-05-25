using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Services.Models.ServiceDTOs;

namespace GrandRepairAuto.Services.Contracts
{
    public interface IServiceService : IGenericService<Service, int, ServiceDTO, ServiceCreateDTO, ServiceDTO>
    {
    }
}
