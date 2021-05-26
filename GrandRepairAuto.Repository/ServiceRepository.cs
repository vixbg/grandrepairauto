using GrandRepairAuto.Data;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Repository.Contracts;

namespace GrandRepairAuto.Repository
{
    public class ServiceRepository : GenericRepository<Service, int>, IServiceRepository
    {
        public ServiceRepository(GarageContext context) : base(context) { }
    }
}
