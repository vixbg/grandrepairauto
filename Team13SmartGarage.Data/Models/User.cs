using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Team13SmartGarage.Data.Models
{
    public class User : Entity<int>, ISoftDeletable
    {
        public DateTime? DeletedOn { get; set; }
       
    }
}
