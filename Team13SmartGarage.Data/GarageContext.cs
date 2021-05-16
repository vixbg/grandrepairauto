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
            modelBuilder.Entity<Orders>()
                .HasOne<Users>(o => o.User)
                .WithMany()
                .Metadata.DeleteBehavior = DeleteBehavior.Restrict;
            modelBuilder.Entity<Orders>()
                .HasOne<Vehicles>(o => o.Vehicle)
                .WithMany()
                .Metadata.DeleteBehavior = DeleteBehavior.Restrict;
        }

        public DbSet<Vehicles> Vehicles { get; set; }
        public DbSet<VehicleModels> VehicleModels { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Manufacturers> Manufacturers { get; set; }
        public DbSet<CustomerService> CustomerServices { get; set; }
    }
}
