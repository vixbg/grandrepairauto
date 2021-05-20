using Team13SmartGarage.Data;
using Team13SmartGarage.Data.Models;

namespace Team13SmartGarage.Repository
{
    public class ManufacturerRepository : GenericRepository<Manufacturer, int>
    {
        public ManufacturerRepository(GarageContext context) : base(context) { }
    }
}
