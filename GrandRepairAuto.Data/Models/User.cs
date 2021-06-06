using GrandRepairAuto.Data.Models.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace GrandRepairAuto.Data.Models
{
    public class User : IdentityUser<int>, IEntity<int>, ISoftDeletable
    {
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 20 characters")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 20 characters")]
        public string LastName { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
