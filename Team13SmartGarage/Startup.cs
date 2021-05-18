using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Team13SmartGarage.Data;
using Team13SmartGarage.Data.Models;
using Team13SmartGarage.Repository;
using Team13SmartGarage.Services;
using Team13SmartGarage.Services.Models.ManufacturerDTOs;
using Team13SmartGarage.Services.Models.OrderDTOs;
using Team13SmartGarage.Services.Models.VehiclesDTOs;

namespace Team13SmartGarage
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void AddAutomapper(IServiceCollection services)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Order, OrderDTO>().ReverseMap();
                c.CreateMap<Order, OrderCreateDTO>().ReverseMap();
                c.CreateMap<Manufacturer, ManufacturerDTO>().ReverseMap();
                c.CreateMap<Manufacturer, ManufacturerCreateDTO>().ReverseMap();
            });

            services.AddSingleton(config.CreateMapper());
        }

        // This method gets called by the runtime. Use this method to add services to the Container.
        public void ConfigureServices(IServiceCollection services)
        {
            AddAutomapper(services);
            services.AddControllersWithViews();

            services.AddDbContext<GarageContext>(options => options.UseSqlServer(Configuration.GetConnectionString("EntityString")));

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            // Repositories
            services.AddScoped<GenericRepository<Order, int>>();
            services.AddScoped<GenericRepository<Manufacturer, int>>();
            services.AddScoped<GenericRepository<Vehicle, int>>();

            // Services
            services.AddScoped<GenericService<Order, int, OrderDTO, OrderCreateDTO, OrderUpdateDTO>>();
            services.AddScoped<GenericService<Manufacturer, int, ManufacturerDTO, ManufacturerCreateDTO, ManufacturerUpdateDTO>>();
            services.AddScoped<GenericService<Vehicle, int, VehicleDTO, VehicleCreateDTO, VehicleUpdateDTO>>();
            
            services.AddSwaggerGen(c =>
            {
                c.ResolveConflictingActions(a => a.First());
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SmartGarage13", Version = "V1", Description = "This is Swagger documentation about SmartGarage13" });

                var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
                c.IncludeXmlComments(filePath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartGarage13");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
