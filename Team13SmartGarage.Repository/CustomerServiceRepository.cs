using Team13SmartGarage.Data;
using Team13SmartGarage.Data.Models;

namespace Team13SmartGarage.Repository
{
    public class CustomerServiceRepository : GenericRepository<CustomerService, int>
    {
        public CustomerServiceRepository(GarageContext context) : base(context) { }
    }
}
