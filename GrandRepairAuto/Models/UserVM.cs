using System.Collections.Generic;
using System.Linq;

namespace GrandRepairAuto.Web.Models
{

    public class UserVM
    {
        public class RoleCheckbox
        {
            public string Name { get; set; }

            public bool Checked { get; set; }
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string Email { get; set; }

        public string Username { get; set; }

        public string PhoneNumber { get; set; }

        public List<string> Roles { get; set; } = new List<string>();

        public List<RoleCheckbox> RoleSelection { get; set; } = new List<RoleCheckbox>();

        public string RolesString { get => string.Join(", ", Roles); }
    }
}
