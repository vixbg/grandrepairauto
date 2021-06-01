using GrandRepairAuto.Services.Abstract;
using System.Collections.Generic;

namespace GrandRepairAuto.Services.Models.UserDTOs
{
    public class UserDTO : DTO<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string PhoneNumber { get; set; }

        public List<string> Roles { get; set; } = new List<string>();
    }
}
