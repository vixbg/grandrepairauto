namespace Team13SmartGarage.Services.Models.VehicleModelDTOs
{
    public class VehicleModelUpdateDTO : DTO<int>
    {
        public string Name { get; set; }
        public int ManufacturerId { get; set; }
    }
}
