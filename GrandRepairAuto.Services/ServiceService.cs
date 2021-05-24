using AutoMapper;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Repository;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Services.Models.ServiceDTOs;

namespace GrandRepairAuto.Services
{
    public class ServiceService : GenericService<Service, int, ServiceDTO, ServiceCreateDTO, ServiceDTO>, IServiceService
    {
        public ServiceService(GenericRepository<Service, int> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
