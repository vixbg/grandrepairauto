using GrandRepairAuto.Data.Models.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrandRepairAuto.Data.Models
{
    public class User : IdentityUser<int>, IEntity<int>, ISoftDeletable
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
