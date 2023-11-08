using AutoMapper;
using HospitalLibrary.Dto.blood_bank;
using HospitalAPI.Mapper;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository.room;
using HospitalLibrary.Core.Repository.user;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Core.Service.email;
using HospitalLibrary.Middleware;
using HospitalLibrary.Core.Repository.building;
using HospitalLibrary.Core.Repository.doctor;
using HospitalLibrary.Core.Repository.feedback;
using HospitalLibrary.Core.Repository.floor;
using HospitalLibrary.Core.Repository.manager;
using HospitalLibrary.Core.Repository.map;
using HospitalLibrary.Core.Repository.patient;
using HospitalLibrary.Core.Repository.feedback;
using HospitalLibrary.Core.Repository.room;
using HospitalLibrary.Core.Repository.user;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Core.Service.building;
using HospitalLibrary.Core.Service.doctor;
using HospitalLibrary.Core.Service.feedback;
using HospitalLibrary.Core.Service.floor;
using HospitalLibrary.Core.Service.manager;
using HospitalLibrary.Core.Service.map;
using HospitalLibrary.Core.Service.patient;
using HospitalLibrary.Core.Service.feedback;
using HospitalLibrary.Core.Service.room;
using HospitalLibrary.Core.Service.user;
using HospitalLibrary.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Net.Mail;
using HospitalLibrary.Core.Service.blood_bank;
using System;
using HospitalLibrary.Core.Service.appointment;
using HospitalLibrary.Core.Repository.appointment;
using HospitalLibrary.Core.Service.dailyMeasurements;
using HospitalLibrary.Core.Repository.dailyMeasurement;
using HospitalLibrary.Core.Service.payment;
using HospitalLibrary.Core.Repository.payment;

namespace HospitalAPI
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

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc();


            services.AddDbContext<HospitalDbContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("HospitalDb")));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GraphicalEditor", Version = "v1" });
            });

            services.AddSingleton(mapper);
            services.AddScoped<IBloodBankService, BloodBankService>();
            services.AddHttpClient("IntegrationClient", client =>
            {
                client.BaseAddress = new Uri("http://localhost:45488");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("User-Agent", "HttpIntegrationClient");
            });
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IBloodBankService, BloodBankService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IManagerService, ManagerService>();
            services.AddScoped<IManagerRepository, ManagerRepository>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IBuildingService, BuildingService>();
            services.AddScoped<IBuildingRepository, BuildingRepository>();
            services.AddScoped<IFloorService, FloorService>();
            services.AddScoped<IFloorRepository, FloorRepository>();
            services.AddScoped<IMapRoomService, MapRoomService>();
            services.AddScoped<IMapRoomRepository, MapRoomRepository>();
            services.AddScoped<IMapBuildingService, MapBuildingService>();
            services.AddScoped<IMapBuildingRepository, MapBuildingRepository>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IDailyMeasurementsService, DailyMeasurementsService>();
            services.AddScoped<IDailyMeasurementsRepository, DailyMeasurementsRepository>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HospitalAPI v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
