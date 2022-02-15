using GetItDone_Business.Services;
using GetItDone_Database.Database;
using GetItDone_Database.Repository;
using GetItDone_Models.Interfaces.Repository;
using GetItDone_Models.Interfaces.Services;
using GetItDone_Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GetItDone_Backend.Helpers
{
    public static class StartupHelper
    {
        public static void DatabaseConfiguration(this IServiceCollection service, IConfiguration config)
        {
            service.AddDbContext<GIDDatabaseContext>(opt => opt.UseSqlServer(config.GetConnectionString("GetItDoneDatabase")));
        }


        public static void ConfigureDependencyInjection(this IServiceCollection service)
        {

            //Database
            service.AddScoped<IAssignmentRepository, GIDDatabaseRepository>();
            service.AddScoped<ICustomerRepository, GIDDatabaseRepository>();
            service.AddScoped<IEmployeeRepository, GIDDatabaseRepository>();
            service.AddScoped<IProjectManagerRepository, GIDDatabaseRepository>();
            service.AddScoped<ICompanyRepository, GIDDatabaseRepository>();
            service.AddScoped<IProjectRepository, GIDDatabaseRepository>();
            service.AddScoped<IAuthenticationService, AuthenticationService>();

            //Services 
            service.AddScoped<IProjectManagerService, ProjectManagerService>();
            service.AddScoped<ICompanyService, CompanyService>();
            service.AddScoped<ICustomerService, CustomerService>();
            service.AddScoped<IEmployeeService, EmployeeService>();
            service.AddScoped<IProjectService, ProjectService>();
            service.AddScoped<IAssignmentService, AssignmentService>();
            service.AddScoped<GIDDatabaseRepository>();

        }

        public static void ConfigureCors(this IServiceCollection service)
        {
            service.AddCors(opt =>
            {
                opt.AddPolicy("Cors", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .WithOrigins(new[] { "https://localhost:44351" });
                });
            });
        }


        public static void ConfigureAppSettingsValuesInjection(this IServiceCollection services, IConfiguration config)
        {
            AppSettings.SecretKey = config.GetValue<string>("SecretKey:Key");
            AppSettings.HostName = config.GetValue<string>("Url:HostName"); 
            AppSettings.ProjectManagerPassword = config.GetValue<string>("ProjectManagerPassword:Password");
            AppSettings.EmployeePassword = config.GetValue<string>("EmployeePassword:Password");
            AppSettings.CompanyPassword = config.GetValue<string>("CompanyPassword:Password");
            AppSettings.ElectricianPassword = config.GetValue<string>("EmployeePassword:Password");
        }
    }
}
