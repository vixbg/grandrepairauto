using AutoMapper;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Repository;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Services.Models.CustomerServiceDTOs;

namespace GrandRepairAuto.Services
{
    public class CustomerServiceService : GenericService<CustomerService, int, CustomerServiceDTO, CustomerServiceCreateDTO, CustomerServiceUpdateDTO>, ICustomerServiceService
    {
        public CustomerServiceService(GenericRepository<CustomerService, int> repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
