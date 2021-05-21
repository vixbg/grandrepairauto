using GrandRepairAuto.Data;
using GrandRepairAuto.Data.Models;

namespace GrandRepairAuto.Repository
{
    public class VehicleRepository : GenericRepository<Vehicle, int>
    {
        public VehicleRepository(GarageContext context) : base(context) { }
    }
}
