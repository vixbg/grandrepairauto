using GrandRepairAuto.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GrandRepairAuto.Web.Models
{
    public class DetailedOrderVM
    {
        public int Id { get; set; }

        public OrderStatuses Status { get; set; }

        public OrderStatuses NextStatus { get => (OrderStatuses)(((int)this.Status) + 1); }

        public DateTime Date { get; set; }

        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }

        public string UserEmail { get; set; }

        public string UserPhoneNumber { get; set; }

        public string VehicleVehicleModelName { get; set; }

        public string VehicleVehicleModelManufacturerName { get; set; }

        public string VehicleRegPlate { get; set; }

        public string VehicleVehicleType { get; set; }

        public string VehicleEngineType { get; set; }

        public string VehicleVin { get; set; }

        public int ServiceId { get; set; }

        public ServiceVM Service { get; set; }

        public string Currency { get; set; }

        public List<CustomerServiceVM> CustomerServices { get; set; }

        public double TotalPrice { get => CustomerServices.Select(x => x.TotalPrice).Sum(); }
    }
}
