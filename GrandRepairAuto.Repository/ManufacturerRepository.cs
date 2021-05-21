using GrandRepairAuto.Data;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Repository.Contracts;

namespace GrandRepairAuto.Repository
{
    public class ManufacturerRepository : GenericRepository<Manufacturer, int>, IManufacturerRepository
    {
        public ManufacturerRepository(GarageContext context) : base(context) { }
    }
}
