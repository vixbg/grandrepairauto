using GrandRepairAuto.Data;
using GrandRepairAuto.Data.Models;

namespace GrandRepairAuto.Repository
{
    public class VehicleModelRepository : GenericRepository<VehicleModel, int>
    {
        public VehicleModelRepository(GarageContext context) : base(context) { }
    }
}
