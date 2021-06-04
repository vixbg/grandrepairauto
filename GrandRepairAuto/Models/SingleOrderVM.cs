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

        public UserVM Owner { get; set; }

        public VehicleVM Vehicle { get; set; }

        public VehicleModelVM VehicleModel { get; set; }

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
