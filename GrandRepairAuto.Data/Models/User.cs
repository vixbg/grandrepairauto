using System;
using GrandRepairAuto.Data.Models.Abstract;
using GrandRepairAuto.Data.Models.Contracts;
using Microsoft.AspNetCore.Identity;

namespace GrandRepairAuto.Data.Models
{
    public class User : IdentityUser, IEntity<string>, ISoftDeletable
    {
        public DateTime? DeletedOn { get; set; }
       

        //TODO: Create User Model and implement User
    } 
}
