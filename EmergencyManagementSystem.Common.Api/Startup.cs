using AutoMapper;
using EmergencyManagementSystem.Common.BLL.BLL;
using EmergencyManagementSystem.Common.BLL.Validations;
using EmergencyManagementSystem.Common.Common.Interfaces;
using EmergencyManagementSystem.Common.Common.Interfaces.BLL;
using EmergencyManagementSystem.Common.Common.Interfaces.DAL;
using EmergencyManagementSystem.Common.Common.Models;
using EmergencyManagementSystem.Common.DAL;
using EmergencyManagementSystem.Common.DAL.DAL;
using EmergencyManagementSystem.Common.Entities.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace EmergencyManagementSystem.Common.API
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EmergencyManagementSystem.Common.API", Version = "v1" });
            });

            services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(
                Configuration.GetConnectionString("Default"));
                options.UseLazyLoadingProxies();
            }, ServiceLifetime.Scoped);

            services.AddScoped<IUserBLL, UserBLL>();
            services.AddScoped<IUserDAL, UserDAL>();
            services.AddScoped<UserValidation>();
            services.AddScoped<IAddressBLL, AddressBLL>();
            services.AddScoped<IAddressDAL, AddressDAL>();
            services.AddScoped<AddressValidation>();
            services.AddScoped<IEmployeeBLL, EmployeeBLL>();
            services.AddScoped<IEmployeeDAL, EmployeeDAL>();
            services.AddScoped<EmployeeValidation>();
            services.AddScoped<IRequesterBLL, RequesterBLL>();
            services.AddScoped<IRequesterDAL, RequesterDAL>();
            services.AddScoped<RequesterValidation>();

            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserModel, User>();
                cfg.CreateMap<User, UserModel>();
                cfg.CreateMap<AddressModel, Address>();
                cfg.CreateMap<Address, AddressModel>();
                cfg.CreateMap<EmployeeModel, Employee>();//.ForMember(a => a.Address, b => b.MapFrom(c => c.AddressModel));
                cfg.CreateMap<Employee, EmployeeModel>();//.ForMember(a => a.AddressModel, b => b.MapFrom(c => c.Address));
                cfg.CreateMap<RequesterModel, Requester>();
                cfg.CreateMap<Requester, RequesterModel>();

            }).CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Context context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmergencyManagementSystem.Common.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            context.Database.Migrate();
        }
    }
}
