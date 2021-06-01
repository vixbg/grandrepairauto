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
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using GrandRepairAuto.Web.Models;

namespace GrandRepairAuto
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public static void AddAutomapper(IServiceCollection services)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Order, OrderDTO>().ReverseMap();
                c.CreateMap<Order, OrderCreateDTO>().ReverseMap();
                c.CreateMap<Order, OrderUpdateDTO>().ReverseMap();
                c.CreateMap<Manufacturer, ManufacturerDTO>().ReverseMap();
                c.CreateMap<Manufacturer, ManufacturerCreateDTO>().ReverseMap();
                c.CreateMap<Manufacturer, ManufacturerUpdateDTO>().ReverseMap();
                c.CreateMap<Service, ServiceCreateDTO>().ReverseMap();
                c.CreateMap<Service, ServiceDTO>().ReverseMap();
                c.CreateMap<Service, ServiceUpdateDTO>().ReverseMap();
                c.CreateMap<VehicleModel, VehicleModelDTO>().ReverseMap();
                c.CreateMap<VehicleModel, VehicleModelCreateDTO>().ReverseMap();
                c.CreateMap<VehicleModel, VehicleModelUpdateDTO>().ReverseMap();
                c.CreateMap<CustomerService, CustomerServiceDTO>().ReverseMap();
                c.CreateMap<CustomerService, CustomerServiceCreateDTO>().ReverseMap();
                c.CreateMap<CustomerService, CustomerServiceUpdateDTO>().ReverseMap();
                c.CreateMap<Vehicle, VehicleCreateDTO>().ReverseMap();
                c.CreateMap<Vehicle, VehicleDTO>().ReverseMap();
                c.CreateMap<Vehicle, VehicleUpdateDTO>().ReverseMap();

                // Tests only
                c.CreateMap<CustomerServiceCreateDTO, CustomerServiceUpdateDTO>().ReverseMap();
                c.CreateMap<OrderCreateDTO, OrderUpdateDTO>().ReverseMap();
                c.CreateMap<ManufacturerCreateDTO, ManufacturerUpdateDTO>().ReverseMap();
                c.CreateMap<VehicleCreateDTO, VehicleUpdateDTO>().ReverseMap();
                c.CreateMap<VehicleModelCreateDTO, VehicleModelUpdateDTO>().ReverseMap();
                c.CreateMap<ServiceCreateDTO, ServiceUpdateDTO>().ReverseMap();

                //MVC
                c.CreateMap<ServiceCreateDTO, ServiceVM>().ReverseMap();
                c.CreateMap<ServiceDTO, ServiceVM>().ReverseMap();
                c.CreateMap<ServiceUpdateDTO, ServiceVM>().ReverseMap();
            });

            services.AddSingleton(config.CreateMapper());
        }

        // This method gets called by the runtime. Use this method to add services to the Container.
        public void ConfigureServices(IServiceCollection services)
        {
            AddAutomapper(services);
            services.AddControllersWithViews().AddFluentValidation();
            var connectionString = Configuration.GetConnectionString("EntityString");

            services.AddDbContext<GarageContext>(options => options.UseSqlServer(connectionString));

            services.AddIdentity<User, UserRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);
                options.SignIn.RequireConfirmedEmail = true;                
            })
                .AddEntityFrameworkStores<GarageContext>()
                .AddDefaultTokenProviders();

            services.Configure<CookieAuthenticationOptions>(options =>
            {
                options.Cookie.IsEssential = true;
            });

            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = c => c.UseSqlServer(connectionString,
                        sql => sql.MigrationsAssembly(typeof(GarageContext).Assembly.GetName().Name));
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = c => c.UseSqlServer(connectionString,
                        sql => sql.MigrationsAssembly(typeof(GarageContext).Assembly.GetName().Name));
                })
                .AddAspNetIdentity<User>();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            )
                .AddFluentValidation(v => v.RegisterValidatorsFromAssemblyContaining<VehicleValidator>());

            services.AddAuthentication()
                .AddCookie(cfg =>
                {
                    cfg.Cookie.SameSite = SameSiteMode.Strict;
                    cfg.AccessDeniedPath = "/Account/Login";
                    cfg.LoginPath = "/Account/Login";
                });

            services.AddAuthorization();

            // Repositories
            services.AddScoped<ICustomerServiceRepository, CustomerServiceRepository>();
            services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IVehicleModelRepository, VehicleModelRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();            


            // Services
            services.AddScoped<ICustomerServiceService, CustomerServiceService>();
            services.AddScoped<IManufacturerService, ManufacturerService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IVehicleModelService, VehicleModelService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IEmailService, EmailService>();


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
            app.UseIdentityServer();
            app.UseCookiePolicy(new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
                Secure = CookieSecurePolicy.None
            });

            app.UseRouting();

            app.UseAuthentication();
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
