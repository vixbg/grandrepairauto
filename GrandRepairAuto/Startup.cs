using AutoMapper;
using FluentValidation.AspNetCore;
using GrandRepairAuto.Data;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Repository;
using GrandRepairAuto.Repository.Contracts;
using GrandRepairAuto.Services;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Validators;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using GrandRepairAuto.Web.Services;
using Swashbuckle.AspNetCore.Filters;

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
            services.AddSingleton(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            }).CreateMapper());
        }

        // This method gets called by the runtime. Use this method to add services to the Container.
        public void ConfigureServices(IServiceCollection services)
        {
            AddAutomapper(services);

            services.AddControllersWithViews().AddFluentValidation();
            var connectionString = Configuration.GetConnectionString("EntityString");

            services.AddDbContext<GarageContext>(options => options
            .UseLazyLoadingProxies()
            .UseSqlServer(connectionString));

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
                .AddProfileService<GrandRepairProfileService>()
                .AddAspNetIdentity<User>();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            )
                .AddFluentValidation(v => v.RegisterValidatorsFromAssemblyContaining<VehicleValidator>());

            services.AddAuthentication()
                .AddJwtBearer("Bearer", options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.Audience = "api";
                    options.Authority = Configuration.GetValue<string>("Authorization");
                })
                .AddCookie(cfg =>
                {
                    cfg.Cookie.SameSite = SameSiteMode.Strict;
                    cfg.AccessDeniedPath = "/Account/Login";
                    cfg.LoginPath = "/Account/Login";
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("api", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "api");
                });
            });

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
            services.AddScoped<IOrderWithCustomerServicesService, OrderWithCustomerServicesService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IVehicleModelService, VehicleModelService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IVehicleWithModelAndMakeService, VehicleWithModelAndMakeService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ICurrencyConverter, CurrencyConverter>();


            services.AddSwaggerGen(c =>
            {
                c.ResolveConflictingActions(a => a.First());
                
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GrandRepairAuto", Version = "V1", Description = "This is Swagger documentation about GrandRepairAuto" });
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme() {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow {
                            AuthorizationUrl = new Uri(Configuration.GetValue<string>("Authorization") + "/connect/authorize"),
                            TokenUrl = new Uri(Configuration.GetValue<string>("Authorization") + "/connect/token"),
                            Scopes = new Dictionary<string, string>()
                            {
                                { "api", "API" }
                            }
                        }
                    }
                });

                c.OperationFilter<SecurityRequirementsOperationFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
                c.IncludeXmlComments(filePath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Errors/Status/500");
            } 
            app.UseStatusCodePagesWithReExecute("/Errors/Status/{0}");
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
                c.OAuthClientId("api");
                c.OAuthClientSecret("api");
                c.OAuthScopes("api");
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
