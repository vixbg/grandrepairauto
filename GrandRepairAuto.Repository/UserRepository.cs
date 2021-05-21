using GrandRepairAuto.Data;
using GrandRepairAuto.Data.Models;

namespace GrandRepairAuto.Repository
{
    public class UserRepository : GenericRepository<User, int>
    {
        public UserRepository(GarageContext context) : base(context) { }
    }
}
