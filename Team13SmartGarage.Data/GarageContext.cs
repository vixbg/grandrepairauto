using System;
using Microsoft.CodeAnalysis;
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

            modelBuilder.Entity<VehicleModel>()
                .HasOne<Manufacturer>(vm => vm.Manufacturer)
                .WithMany(m => m.VehicleModels)
                .Metadata.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<Vehicle>()
                .HasOne<VehicleModel>(v => v.VehicleModel)
                .WithMany()
                .Metadata.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<Vehicle>()
                .HasOne<User>(v => v.Owner)
                .WithMany()
                .Metadata.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<CustomerService>()
                .HasOne<Service>(c => c.Service)
                .WithMany()
                .Metadata.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<CustomerService>()
                .HasOne<Order>(c => c.Order)
                .WithMany(o => o.CustomerServices)
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
