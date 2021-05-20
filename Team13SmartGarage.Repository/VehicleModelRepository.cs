using Team13SmartGarage.Data;
using Team13SmartGarage.Data.Models;

namespace Team13SmartGarage.Repository
{
    public class VehicleModelRepository : GenericRepository<VehicleModel, int>
    {
        public VehicleModelRepository(GarageContext context) : base(context) { }
    }
}
