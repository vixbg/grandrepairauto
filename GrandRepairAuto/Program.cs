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

            if (! await dbContext.Roles.AnyAsync())
            {
                await dbContext.Roles.AddAsync(new UserRole() {
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

            if (!await dbContext.Users.AnyAsync())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var newUser = new User
                {
                    Email = "admin@grandrepair.com",
                    UserName = "admin@grandrepair.com",
                    EmailConfirmed = true
                };
                if( (await userManager.CreateAsync(newUser, "12345678")).Succeeded )
                {
                    await userManager.AddToRoleAsync(newUser, Roles.Admin);
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
