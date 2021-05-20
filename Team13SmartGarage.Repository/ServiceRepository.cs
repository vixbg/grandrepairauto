using Team13SmartGarage.Data;
using Team13SmartGarage.Data.Models;

namespace Team13SmartGarage.Repository
{
    public class ServiceRepository : GenericRepository<Service, int>
    {
        public ServiceRepository(GarageContext context) : base(context) { }
    }
}
