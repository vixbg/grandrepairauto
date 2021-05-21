using GrandRepairAuto.Data;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Repository.Contracts;

namespace GrandRepairAuto.Repository
{
    public class CustomerServiceRepository : GenericRepository<CustomerService, int>, ICustomerServiceRepository
    {
        public CustomerServiceRepository(GarageContext context) : base(context) { }
    }
}
