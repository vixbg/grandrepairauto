using System;
using System.Collections.Generic;
using System.Text;
using Team13SmartGarage.Data.Enums;
using Team13SmartGarage.Data.Models;

namespace Team13SmartGarage.Services.Models.VehicleDTOs
{
    public class VehicleGetDTO
    {
        public VehicleGetDTO(Vehicles vehicle)
        {
            this.VehicleId = vehicle.VehicleId;
            this.RegPlate = vehicle.RegPlate;
            this.Manufacturer = vehicle.Manufacturer;
            this.VehicleType = vehicle.VehicleType;
            this.EngineType = vehicle.EngineType;
            this.Vin = vehicle.Vin;
            this.Model = vehicle.Model;
            this.Color = vehicle.Color;
            this.Owner = vehicle.Owner;
        }

        public int VehicleId { get; set; }
        public string RegPlate { get; set; }

        //public int ManufacturerId { get; set; }
        public Manufacturers Manufacturer { get; set; }
        public VehicleTypes VehicleType { get; set; }
        public EngineTypes EngineType { get; set; }
        public string Vin { get; set; }

        //public int ModelId { get; set; }
        public VehicleModels Model { get; set; }
        public int Mileage { get; set; }
        public string Color { get; set; }
        //public int OwnerId { get; set; }
        public Users Owner { get; set; }

        //public DateTime IsDeleted { get; set; }
    }
}
