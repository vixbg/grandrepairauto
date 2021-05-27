using GrandRepairAuto.Data;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Repository.Contracts;

namespace GrandRepairAuto.Repository
{
    public class UserRepository : GenericRepository<User, string>, IUserRepository
    {
        public UserRepository(GarageContext context) : base(context) { }
    }
}
