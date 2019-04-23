using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using VehicleWebApp.MVC.Repositories;
using VehicleWebApp.MVC.Services;
using VehicleWebApp.Service.Contexts;
using VehicleWebApp.Service.Repositories;
using VehicleWebApp.Service.Services;

namespace VehicleWebApp.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Register db context with dependency injection
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AppDbContext"), b => b.MigrationsAssembly("VehicleWebApp.MVC")));

            // Bind service interfaces
            services.AddScoped<IVehicleMakeService, VehicleMakeService>();
            services.AddScoped<IVehicleModelService, VehicleModelService>();

            // Bind repository interfaces
            services.AddScoped<IVehicleMakeRepository, VehicleMakeRepository>();
            services.AddScoped<IVehicleModelRepository, VehicleModelRepository>();

            services.AddAutoMapper();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
