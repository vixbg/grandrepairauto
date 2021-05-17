using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Team13SmartGarage.Data;
using Team13SmartGarage.Data.Models;
using Team13SmartGarage.Services.Contracts;
using Team13SmartGarage.Services.Models.VehicleDTOs;

namespace Team13SmartGarage.Services.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly GarageContext dbContext;

        public VehicleService(GarageContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public VehicleCreateDTO Create(VehicleCreateDTO vehicleDTO)
        {
            if (vehicleDTO == null)
            {
                throw new Exception("Input vehicle is null or empty.");
            }

            var newVehicle = new Vehicles
            {

            }

            this.dbContext.Vehicles.Add(newVehicle);
            this.dbContext.SaveChanges();

            //maybe it's better to return the id of the created vehicle for the employee part.
            return vehicleDTO;
        }

        public VehicleGetDTO Get(int id)
        {
            var vehicle = this.dbContext.Vehicles
                .Include(v => v.Manufacturer)
                .Include(v => v.Owner)
                .FirstOrDefault(v => v.VehicleId == id);
                

            if (vehicle == null || vehicle.IsDeleted != null)
            {
                throw new Exception("No vehicle found with this ID.");
            }

            VehicleGetDTO vehicleDTO = new VehicleGetDTO(vehicle);

            return vehicleDTO;
        }

        public List<VehicleGetDTO> GetAll()
        {
            var vehicles = this.dbContext.Vehicles
                .Include(v => v.Manufacturer)
                .Include(v => v.Owner)
                .Where(v => v.IsDeleted == null)
                .ToList();

            if (vehicles.Count == 0)
            {
                throw new Exception("No vehicles found.");
            }

            List<VehicleGetDTO> vehiclesDTO = vehicles.Select(v => new VehicleGetDTO(v)).ToList();

            return vehiclesDTO;
        }

        public VehicleUpdateDTO Update(VehicleUpdateDTO vehicleDTO)
        {
            if (vehicleDTO == null)
            {
                throw new Exception("Input vehicle is null or empty.");
            }

            var vehicle = this.dbContext.Vehicles.FirstOrDefault(v => v.VehicleId == vehicleDTO.VehicleId);

            if (vehicle == null)
            {
                throw new Exception("No vehicle found with this ID.");
            }

            vehicle.VehicleId = vehicleDTO.VehicleId;
            vehicle.RegPlate = vehicleDTO.RegPlate;
            vehicle.Color = vehicleDTO.Color;

            this.dbContext.SaveChanges();

            return vehicleDTO;
        }
        
    }
}
