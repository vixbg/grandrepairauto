using Team13SmartGarage.Data;
using Team13SmartGarage.Data.Models;

namespace Team13SmartGarage.Repository
{
    public class UserRepository : GenericRepository<User, int>
    {
        public UserRepository(GarageContext context) : base(context) { }
    }
}
