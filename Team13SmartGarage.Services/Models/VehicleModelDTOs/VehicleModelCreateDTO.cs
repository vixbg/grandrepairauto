namespace Team13SmartGarage.Services.Models.VehicleModelDTOs
{
    public class VehicleModelCreateDTO : DTO<int>
    {
        public string Name { get; set; }
        public int ManufacturerId { get; set; }
    }
}
