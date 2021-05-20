using Team13SmartGarage.Data;
using Team13SmartGarage.Data.Models;

namespace Team13SmartGarage.Repository
{
    public class VehicleRepository : GenericRepository<Vehicle, int>
    {
        public VehicleRepository(GarageContext context) : base(context) { }
    }
}
