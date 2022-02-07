using GetItDone_Business.Services;
using GetItDone_Database.Database;
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
            service.AddScoped<IAuthenticationService, AuthenticationService>();
            service.AddScoped<AuthenticationService>();
        }


        public static void ConfigureAppSettingsValuesInjection(this IServiceCollection services, IConfiguration config)
        {
            AppSettings.SecretKey = config.GetValue<string>("SecretKey:Key");
            AppSettings.HostName = config.GetValue<string>("Url:HostName"); 
            AppSettings.ProjectManagerPassword = config.GetValue<string>("ProjectManagerPassword:Password");
            AppSettings.EmployeePassword = config.GetValue<string>("EmployeePassword:Password");
            AppSettings.CompanyPassword = config.GetValue<string>("CompanyPassword:Password");
        }
    }
}
