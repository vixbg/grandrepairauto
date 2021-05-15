using System;
using Microsoft.EntityFrameworkCore;

namespace Team13SmartGarage.Data
{
    public class GarageContext : DbContext
    {
        public GarageContext(DbContextOptions<GarageContext> options) : base (options)
        {
            
        }  

    }
}
