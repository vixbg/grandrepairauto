using System;
using GrandRepairAuto.Data.Models.Abstract;
using GrandRepairAuto.Data.Models.Contracts;

namespace GrandRepairAuto.Data.Models
{
    public class User : Entity<int>, ISoftDeletable
    {
        public DateTime? DeletedOn { get; set; }
       

        //TODO: Create User Model and implement User
    } 
}
