using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Team13SmartGarage.Data;
using Team13SmartGarage.Data.Models;
using Team13SmartGarage.Repository.Contracts;

namespace Team13SmartGarage.Repository
{
    public class OrderRepository : GenericRepository<Order, int>
    {
        public OrderRepository(GarageContext context) : base(context) {}
    }
}
