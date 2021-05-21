using GrandRepairAuto.Data;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Repository.Contracts;

namespace GrandRepairAuto.Repository
{
    public class VehicleRepository : GenericRepository<Vehicle, int>, IVehicleRepository
    {
        public VehicleRepository(GarageContext context) : base(context) { }
    }
}
