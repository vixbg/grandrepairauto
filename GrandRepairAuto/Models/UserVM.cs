using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 20 characters")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 20 characters")]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be 10 digits")]
        public string PhoneNumber { get; set; }

        public List<string> Roles { get; set; } = new List<string>();

        public List<RoleCheckbox> RoleSelection { get; set; } = new List<RoleCheckbox>();

        public string RolesString { get => string.Join(", ", Roles); }
    }
}
