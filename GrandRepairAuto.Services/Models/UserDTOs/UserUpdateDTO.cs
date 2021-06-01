using GrandRepairAuto.Services.Contracts;
using System.Collections.Generic;

namespace GrandRepairAuto.Services.Models.UserDTOs
{
    public class UserUpdateDTO : IDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public List<string> Roles { get; set; }
    }
}
