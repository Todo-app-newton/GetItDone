using GetItDone_Database.Database;
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
    }
}
