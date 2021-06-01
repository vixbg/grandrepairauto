using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GrandRepairAuto.Data;
using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Data.Models;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using GrandRepairAuto.Data.Models.SeedModels;
using System;

namespace GrandRepairAuto
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            MigrateDatabase(host);
            host.Run();
        }

        private static async void MigrateDatabase(IHost host)
        {
            using var scope = host.Services.CreateScope();
            await scope.ServiceProvider.GetService<PersistedGrantDbContext>().Database.MigrateAsync();
            await scope.ServiceProvider.GetService<ConfigurationDbContext>().Database.MigrateAsync();
            await using var dbContext = scope.ServiceProvider.GetService<GarageContext>();
            await dbContext.Database.MigrateAsync();

            if (!await dbContext.Roles.AnyAsync())
            {
                await dbContext.Roles.AddAsync(new UserRole()
                {
                    Name = Roles.Admin,
                    NormalizedName = Roles.Admin.ToUpper()
                });
                await dbContext.Roles.AddAsync(new UserRole()
                {
                    Name = Roles.Employee,
                    NormalizedName = Roles.Employee.ToUpper()
                });
                await dbContext.Roles.AddAsync(new UserRole()
                {
                    Name = Roles.Customer,
                    NormalizedName = Roles.Customer.ToUpper()
                });

                await dbContext.SaveChangesAsync();
            }

            var manufacturerFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Seed", "ManufacturersAndModels.json");

            if (!await dbContext.Manufacturers.AnyAsync() && File.Exists(manufacturerFile))
            {
                SetIdentityInsert<Manufacturer>(dbContext, true);
                SetIdentityInsert<VehicleModel>(dbContext, true);
                var extracts = JsonConvert.DeserializeObject<List<ManufacturersAndModelsSeedModel>>(File.ReadAllText(manufacturerFile));

                foreach (var e in extracts)
                {
                    var manufacturer = new Manufacturer()
                    {
                        Name = e.brand,
                        VehicleModels = new List<VehicleModel>()
                    };

                    foreach (var model in e.models)
                    {
                        var vehicleModel = new VehicleModel()
                        {
                            Name = model
                        };

                        manufacturer.VehicleModels.Add(vehicleModel);
                    }

                    await dbContext.Manufacturers.AddAsync(manufacturer);
                }

                dbContext.SaveChanges();

                SetIdentityInsert<Manufacturer>(dbContext, false);
                SetIdentityInsert<VehicleModel>(dbContext, false);
            }


            var usersFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Seed", "Users.json");

            if (!await dbContext.Users.AnyAsync() && File.Exists(usersFile))
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var extracts = JsonConvert.DeserializeObject<List<UserSeedModel>>(File.ReadAllText(usersFile));

                foreach (var e in extracts)
                {
                    var user = new User()
                    {
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        Email = e.Email,
                        EmailConfirmed = true,
                        UserName = e.Username,
                        PhoneNumber = e.PhoneNumber
                    };

                    if ((await userManager.CreateAsync(user, e.Password)).Succeeded)
                    {
                        foreach (var role in e.Roles)
                        {
                            await userManager.AddToRoleAsync(user, role);
                        }
                    } 
                }
            }            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


        /// <summary>
        /// Turns ON and OFF IDENTITY INSERT for specific database table.
        /// </summary>
        /// <typeparam name="TEntity">Generic that takes the form of the Model that will show which table to be used.</typeparam>
        /// <param name="dbContext">Database Instance</param>
        /// <param name="on">Boolean to change ON or OFF of the parameter.</param>
        private static void SetIdentityInsert<TEntity>(DbContext dbContext, bool on)
        {
            var entityType = dbContext.Model.FindEntityType(typeof(TEntity));
            var query =
                $"SET IDENTITY_INSERT dbo.{entityType.GetTableName()} {(on ? "ON" : "OFF")};";
            dbContext.Database.ExecuteSqlRaw(query);
        }
    }
}
