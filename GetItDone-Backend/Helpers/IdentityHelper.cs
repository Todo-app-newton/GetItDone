using GetItDone_Database.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetItDone_Backend.Helpers
{
    public static class IdentityHelper
    {

        public static void ConfigureBearer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(cfg =>
            {
                cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(conf =>
                {
                    var secretKey = Encoding.UTF8.GetBytes(configuration["SecretKey:Key"]);
                    var key = new SymmetricSecurityKey(secretKey);
                    conf.Events = new JwtBearerEvents()
                    {
                        OnMessageReceived = context =>
                        {
                            if (context.Request.Cookies.ContainsKey("X-Access-Token"))
                            {
                                context.Token = context.Request.Cookies["X-Access-Token"];
                            }
                            return Task.CompletedTask;
                        }
                    };

                    conf.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = configuration["Url:HostName"],
                        ValidateAudience = true,
                        ValidAudience = configuration["Url:HostName"],
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key,
                    };

                    conf.SaveToken = true;
                });
        }


        public static void ConfigureIdentityOptions(this IServiceCollection service)
        {
            service.AddIdentityCore<IdentityUser>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 6;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<GIDDatabaseContext>();
        }
    }
}
