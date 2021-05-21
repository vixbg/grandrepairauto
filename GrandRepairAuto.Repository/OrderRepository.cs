using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using GrandRepairAuto.Data;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Repository.Contracts;

namespace GrandRepairAuto.Repository
{
    public class OrderRepository : GenericRepository<Order, int>
    {
        public OrderRepository(GarageContext context) : base(context) {}
    }
}
