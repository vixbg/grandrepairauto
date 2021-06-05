using GrandRepairAuto.Data.Enums;
using System;
using System.Collections.Generic;

namespace GrandRepairAuto.Web.Models
{
    public class SingleOrderVM
    {
        public int Id { get; set; }

        public OrderStatuses Status { get; set; }

        public DateTime Date { get; set; }

        public UserVM User { get; set; }

        public VehicleVM Vehicle { get; set; }

        public string VehicleModelName { get; set; }

        public string VehicleManufacturerName { get; set; }

        public int ServiceId { get; set; }

        public ServiceVM Service { get; set; }

        public List<CustomerServiceVM> CustomerServices { get; set; }

        public double TotalPrice { get; set; }

    }
}
