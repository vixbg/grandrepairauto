using System.ComponentModel.DataAnnotations;

namespace GrandRepairAuto.Web.Models
{
    public class ManufacturerVM
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Manufacturer name should be between 1 and 30 characters.")] 
        public string Name { get; set; }
    }
}
