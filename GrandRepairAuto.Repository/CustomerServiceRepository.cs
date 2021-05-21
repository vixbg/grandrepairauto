using GrandRepairAuto.Data;
using GrandRepairAuto.Data.Models;

namespace GrandRepairAuto.Repository
{
    public class CustomerServiceRepository : GenericRepository<CustomerService, int>
    {
        public CustomerServiceRepository(GarageContext context) : base(context) { }
    }
}
