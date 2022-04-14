using AutoMapper;
using HRMS.API.Models;
using HRMS.API.Repositories.UnitOfWork;
using HRMS.API.Services;
using HRMS.API.Services.IServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API
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
            //Register Application DB Context
            services.AddDbContext<ApplicationDbContext>(options=>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));

            //Register Mapping Configurations
            IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
            services.AddSingleton(mapper);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());                              
            
            //Register all the Controllers
            services.AddControllers();

            services.AddLogging();

            services.AddCors(options =>
            {
                options.AddPolicy("HRMSWebCorsPolicy",
                    builder => builder.WithOrigins("http://localhost:")
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            //Register HttpContext Class
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Register UnitOfWork
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //Register All the Services
            services.AddTransient<IEmployeeService, EmployeeService>();

            services.AddTransient<IClientService, ClientService>();

            services.AddTransient<IContactDetailsService, ContactDetailsService>();

            services.AddTransient<IEmployementTypeService, EmployementTypeService>();
            services.AddTransient<IEmployeeProjectService, EmployeeProjectService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IHolidayService, HolidayService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IDesignationService, DesignationService>();
            services.AddTransient<ILeaveService, LeaveService>();
            //Register Swagger UI
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HRMS.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HRMS.API v1"));
            }           

            app.UseCors("HRMSWebCorsPolicy");
           
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
