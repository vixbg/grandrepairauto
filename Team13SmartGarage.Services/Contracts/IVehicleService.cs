using System;
using System.Collections.Generic;
using System.Text;
using Team13SmartGarage.Services.Models.VehicleDTOs;

namespace Team13SmartGarage.Services.Contracts
{
    public interface IVehicleService
    {
        VehicleGetDTO Get(int id);

        List<VehicleGetDTO> GetAll();

        VehicleCreateDTO Create(VehicleCreateDTO vehicleDTO);

        VehicleUpdateDTO Update(VehicleUpdateDTO vehicleDTO);
    }
}
