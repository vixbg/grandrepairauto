using GrandRepairAuto.Data.Enums;
using System;
using System.Collections.Generic;
using GrandRepairAuto.Services.Models.CustomerServiceDTOs;

namespace GrandRepairAuto.Web.Models
{
    public class SingleOrderVM
    {
        public DateTime Date { get; set; }

        public OrderStatuses Status { get; set; }

        public int OwnerId { get; set; }

        public string Owner { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int VehicleId { get; set; }

        public string Vehicle { get; set; }

        public string RegPlate { get; set; }

        public string Vin { get; set; }

        public string VehicleType { get; set; }

        public string EngineType { get; set; }

        public int Mileage { get; set; }

        public string Color { get; set; }

        public int VehicleModelId { get; set; }

        public string VehicleModel { get; set; }

        public string Manufacturer { get;set; }

        public int ServiceId { get; set; }

        public string Service { get; set; }

        public int CustomerServiceId { get; set; }

        public List<CustomerServiceDTO> CustomerServices { get; set; }

        public string CustomerService { get; set; }

        public ServiceStatuses CustomerServiceStatus { get; set; }
        
        public DateTime CustomerServiceDate { get; set; }

        public double TotalPrice { get; set; }













    }
}
