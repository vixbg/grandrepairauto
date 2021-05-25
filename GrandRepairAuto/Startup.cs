using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using GrandRepairAuto.Data;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Repository;
using GrandRepairAuto.Repository.Contracts;
using GrandRepairAuto.Services;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Services.Models.CustomerServiceDTOs;
using GrandRepairAuto.Services.Models.ManufacturerDTOs;
using GrandRepairAuto.Services.Models.OrderDTOs;
using GrandRepairAuto.Services.Models.ServiceDTOs;
using GrandRepairAuto.Services.Models.VehicleModelDTOs;
using GrandRepairAuto.Services.Models.VehiclesDTOs;
using GrandRepairAuto.Validators;

namespace GrandRepairAuto
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
                c.CreateMap<Order, OrderUpdateDTO>().ReverseMap();
                c.CreateMap<Manufacturer, ManufacturerDTO>().ReverseMap();
                c.CreateMap<Manufacturer, ManufacturerCreateDTO>().ReverseMap();
                c.CreateMap<Service, ServiceCreateDTO>().ReverseMap();
                c.CreateMap<Service, ServiceDTO>().ReverseMap();
                c.CreateMap<VehicleModel, VehicleModelDTO>().ReverseMap();
                c.CreateMap<VehicleModel, VehicleModelCreateDTO>().ReverseMap();
                c.CreateMap<CustomerService, CustomerServiceDTO>().ReverseMap();
                c.CreateMap<CustomerService, CustomerServiceCreateDTO>().ReverseMap();
                c.CreateMap<CustomerService, CustomerServiceUpdateDTO>().ReverseMap();
                c.CreateMap<Vehicle, VehicleCreateDTO>().ReverseMap();
                c.CreateMap<Vehicle, VehicleDTO>().ReverseMap();
                c.CreateMap<Vehicle, VehicleUpdateDTO>().ReverseMap();
            });

            services.AddSingleton(config.CreateMapper());
        }

        // This method gets called by the runtime. Use this method to add services to the Container.
        public void ConfigureServices(IServiceCollection services)
        {
            AddAutomapper(services);
            services.AddControllersWithViews().AddFluentValidation();

            services.AddDbContext<GarageContext>(options => options.UseSqlServer(Configuration.GetConnectionString("EntityString")));

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            )
                .AddFluentValidation(v => v.RegisterValidatorsFromAssemblyContaining<VehicleValidator>());



            // Repositories
            services.AddScoped<ICustomerServiceRepository, CustomerServiceRepository>();
            services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IVehicleModelRepository, VehicleModelRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();


            // Services //TODO: Implement Interfaces.
            services.AddScoped<ICustomerServiceService, CustomerServiceService>();
            services.AddScoped<IManufacturerService, ManufacturerService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IVehicleModelService, VehicleModelService>();
            services.AddScoped<IVehicleService, VehicleService>();


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
