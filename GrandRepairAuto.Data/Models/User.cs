using GrandRepairAuto.Data.Models.Contracts;
using Microsoft.AspNetCore.Identity;
using System;

namespace GrandRepairAuto.Data.Models
{
    public class User : IdentityUser<int>, IEntity<int>, ISoftDeletable
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
