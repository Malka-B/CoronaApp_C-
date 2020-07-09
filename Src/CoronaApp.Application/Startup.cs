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
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using NServiceBus;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Npgsql;
using NpgsqlTypes;
using NServiceBus.Persistence.Sql;
using System.Data.SqlClient;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;

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
        public async void ConfigureServices(IServiceCollection services)
        {
          {  //var endpointConfiguration = new EndpointConfiguration("CoronaApp");

            //var transport = endpointConfiguration.UseTransport<LearningTransport>();

            
                //var recoverabilityDelayed = endpointConfiguration.Recoverability();
                //recoverabilityDelayed.Delayed(
                //    delayed =>
                //    {
                //        delayed.NumberOfRetries(2);
                //        delayed.TimeIncrease(TimeSpan.FromMinutes(5));
                //    });

                //var recoverabilityImmediate = endpointConfiguration.Recoverability();
                //recoverabilityImmediate.Immediate(
                //    immediate =>
                //    {
                //        immediate.NumberOfRetries(3);
                //    });

                //var endpointInstance = await Endpoint.Start(endpointConfiguration)
                //    .ConfigureAwait(false);
                //var connection = Configuration.GetConnectionString("PersistanceDBConnectionString");

                //var persistence = endpointConfiguration.UsePersistence<SqlPersistence>();

                //var subscription = persistence.SubscriptionSettings();
                //subscription.CacheFor(TimeSpan.FromMinutes(1));
                //persistence.SqlDialect<SqlDialect.MsSqlServer>();
                //persistence.ConnectionBuilder(
                //    connectionBuilder: () =>
                //    {
                //        return new SqlConnection(connection);
                //    });





                //services.AddScoped(typeof(IEndpointInstance), x => endpointInstance);
            }
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IUrlHelper>(x =>
            {
                var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
                var factory = x.GetRequiredService<IUrlHelperFactory>();
                return factory.GetUrlHelper(actionContext);
            });
            services.AddScoped<ILocationService, LocationService>();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                       builder =>
                       {
                           builder.AllowAnyOrigin()
                                  .AllowAnyHeader()
                                  .AllowAnyMethod()
                                  .WithExposedHeaders("X-Pagination");
                       });
            });

            services.AddControllers();

            var key = Encoding.ASCII.GetBytes("ThisIsAnImportantSecret");

            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = false;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddAuthorization();

            //services.AddAuthentication("")
            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc(
                    "CoronaAppOpenAPISpecification",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "CoronaApp API",
                        Version = "1"
                    });
                //var xmlCommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlCommentFullPath = Path.Combine(AppContext);
                setupAction.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                                        new List<string>()
                    }
                });
            });

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

            app.UseCors();

            app.UseSwagger();

            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint(
                    "/swagger/CoronaAppOpenAPISpecification/swagger.json",
                    "CoronaApp API"
                    );
            });

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
