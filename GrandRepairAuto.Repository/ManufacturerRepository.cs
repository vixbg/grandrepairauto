using GrandRepairAuto.Data;
using GrandRepairAuto.Data.Models;

namespace GrandRepairAuto.Repository
{
    public class ManufacturerRepository : GenericRepository<Manufacturer, int>
    {
        public ManufacturerRepository(GarageContext context) : base(context) { }
    }
}
