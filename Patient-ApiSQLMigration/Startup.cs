using API.DataLayer;
using API.DataLayer.IData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_ApiSQLMigration
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IPatientData, PatientData>();
            services.AddSingleton<IBPData, BPData>();
            services.AddSingleton<IBGData, BGData>();
            services.AddSingleton<IWeightData, WeightData>();
            services.AddSingleton<IThresholdData, ThresholdData>();
            services.AddSingleton<INotificationData, NotificationData>();
            services.AddSingleton<ICoachData, CoachData>();
            services.AddSingleton<ICareCoordinatorData, CareCoordinatorData>();
            services.AddSingleton<IDoctorData, DoctorData>();
            services.AddSingleton<ITimeLogData, TimeLogData>();
            services.AddSingleton<IDeviceData, DeviceData>();
            services.AddSingleton<IUserTableData, UserTableData>();


            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins(
                                        "http://localhost:4200"
                                        )
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                    builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .Build();
                });

                options.AddPolicy("signalr",
                    builder => builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()

                    .AllowCredentials()
                    .SetIsOriginAllowed(hostName => true));
            });
            //-------------------------------------------------


            // Enable middleware to serve generated Swagger as a JSON endpoint.  
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Place Info Service API",
                    Version = "v2",
                    Description = "Sample service for Learner",
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(MyAllowSpecificOrigins);
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseCors();

            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v2/swagger.json", "PlaceInfo Services"));
        }
    }
}
