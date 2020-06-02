using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CoronaApp.Services;
using CoronaApp.Services.Models;
using CoronaApp.Api.Controllers;
using CoronaApp.Dal;
using Microsoft.EntityFrameworkCore;

namespace CoronaApp.Api
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
            services.AddControllers();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            //services.AddScoped<ILocationService, LocationTestService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<ICoronaContext, CoronaContext>();
            services.AddMvc();
            services.AddDbContext<CoronaContext>(
                  options => options.UseSqlServer(Configuration.GetConnectionString("CoronaDBConnectionString")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
