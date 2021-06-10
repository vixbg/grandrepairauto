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
using IdentityServer4;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using ApiResource = IdentityServer4.Models.ApiResource;
using ApiScope = IdentityServer4.Models.ApiScope;
using Client = IdentityServer4.Models.Client;
using Secret = IdentityServer4.Models.Secret;

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
            var configContext = scope.ServiceProvider.GetService<ConfigurationDbContext>();
            await configContext.Database.MigrateAsync();

            if (!await configContext.Clients.AnyAsync())
            {
                configContext.Clients.Add(new Client
                {
                    ClientName = "API",
                    ClientId = "api",
                    AllowedGrantTypes = GrantTypes.Code,
                    ClientSecrets = { new Secret("api".Sha256()) },
                    RedirectUris = new List<string>
                    {
                        "http://localhost:5000/swagger/oauth2-redirect.html"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OpenId,
                        "api"
                    },
                    RequirePkce = false,
                    AllowAccessTokensViaBrowser = true,
                    RequireClientSecret = false,
                    RequireConsent = false
                }.ToEntity());
                await configContext.SaveChangesAsync();
            }

            if (!await configContext.ApiScopes.AnyAsync())
            {
                configContext.ApiScopes.Add(new ApiScope
                {
                    Name = "api",
                    Enabled = true
                }.ToEntity());
                await configContext.SaveChangesAsync();
            }

            if (!await configContext.ApiResources.AnyAsync())
            {
                configContext.ApiResources.Add(new ApiResource
                {
                    Name = "api",
                    Scopes = { "api"}
                }.ToEntity());
                await configContext.SaveChangesAsync();
            }

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
            
            var servicesFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Seed", "Services.json");

            if (!await dbContext.Services.AnyAsync() && File.Exists(servicesFile))
            {
                
                var extracts = JsonConvert.DeserializeObject<List<ServiceSeedModel>>(File.ReadAllText(servicesFile));

                foreach (var e in extracts)
                {
                    var service = new Service()
                    {
                        Name = e.Name,
                        PricePerHour = e.PricePerHour,
                        VehicleType = e.VehicleType,
                        WorkHours = e.WorkHours,
                    };

                    await dbContext.Services.AddAsync(service);
                }

                dbContext.SaveChanges();

                SetIdentityInsert<Service>(dbContext, false);
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
