using System;
using Team13SmartGarage.Data.Models.Abstract;
using Team13SmartGarage.Data.Models.Contracts;

namespace Team13SmartGarage.Data.Models
{
    public class User : Entity<int>, ISoftDeletable
    {
        public DateTime? DeletedOn { get; set; }
       

        //TODO: Create User Model and implement User
    } 
}
