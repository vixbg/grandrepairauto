using AutoMapper;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Repository;
using GrandRepairAuto.Repository.Contracts;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Services.Models.CustomerServiceDTOs;

namespace GrandRepairAuto.Services
{
    public class CustomerServiceService : GenericService<CustomerService, int, CustomerServiceDTO, CustomerServiceCreateDTO, CustomerServiceUpdateDTO>, ICustomerServiceService
    {
        public CustomerServiceService(ICustomerServiceRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
