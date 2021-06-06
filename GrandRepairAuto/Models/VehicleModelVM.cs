using System.ComponentModel.DataAnnotations;

namespace GrandRepairAuto.Web.Models
{
    public class VehicleModelVM
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Model name should be between 1 and 30 characters.")]
        public string Name { get; set; }

        public int ManufacturerId { get; set; }

    }
}
