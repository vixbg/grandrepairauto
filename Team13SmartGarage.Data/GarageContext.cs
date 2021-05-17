using System;
using Microsoft.EntityFrameworkCore;
using Team13SmartGarage.Data.Models;

namespace Team13SmartGarage.Data
{
    public class GarageContext : DbContext
    {
        public GarageContext(DbContextOptions<GarageContext> options) : base (options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne<User>(o => o.User)
                .WithMany()
                .Metadata.DeleteBehavior = DeleteBehavior.Restrict;
            modelBuilder.Entity<Order>()
                .HasOne<Vehicle>(o => o.Vehicle)
                .WithMany()
                .Metadata.DeleteBehavior = DeleteBehavior.Restrict;
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<CustomerService> CustomerServices { get; set; }
    }
}
