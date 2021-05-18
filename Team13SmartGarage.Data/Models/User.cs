using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Team13SmartGarage.Data.Models
{
    public class User : Entity<int>
    {
        public DateTime? IsDeleted { get; set; }
       
    }
}
