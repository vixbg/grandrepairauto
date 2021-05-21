using GrandRepairAuto.Data;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Repository.Contracts;

namespace GrandRepairAuto.Repository
{
    public class VehicleModelRepository : GenericRepository<VehicleModel, int>, IVehicleModelRepository
    {
        public VehicleModelRepository(GarageContext context) : base(context) { }
    }
}
