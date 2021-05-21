using GrandRepairAuto.Data;
using GrandRepairAuto.Data.Models;

namespace GrandRepairAuto.Repository
{
    public class ServiceRepository : GenericRepository<Service, int>
    {
        public ServiceRepository(GarageContext context) : base(context) { }
    }
}
