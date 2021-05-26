using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Services.Models.CustomerServiceDTOs;

namespace GrandRepairAuto.Services.Contracts
{
    public interface ICustomerServiceService : IGenericService<CustomerService, int, CustomerServiceDTO, CustomerServiceCreateDTO, CustomerServiceUpdateDTO>
    {
    }
}
