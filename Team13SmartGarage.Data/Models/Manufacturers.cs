using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Team13SmartGarage.Data.Models
{
    public class Manufacturers
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Manufacturer name should be between 1 and 30 characters.")]
        public string Name { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }
}
