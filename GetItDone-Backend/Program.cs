using GetItDone_Database.Database;
using GetItDone_Models.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Security.Claims;

namespace GetItDone_Backend
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            try
            {
                using (var scope = host.Services.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<GIDDatabaseContext>();
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                    context.Database.EnsureCreated();

                    if (!context.Users.Any())
                    {
                        var projectManager = new IdentityUser()
                        {
                            UserName = "ProjectManager",
                            Email = "ProjectManager@PM.com"
                        };

                        var employee = new IdentityUser()
                        {
                            UserName = "Painter",
                            Email = "Painter@Skanska.com"
                        };
                        var employeeTwo = new IdentityUser()
                        {
                            UserName = "Electrician",
                            Email = "Electrician@Skanska.com"
                        };
                        var company = new IdentityUser()
                        {
                            UserName = "SKANSKA",
                            Email = "Skanska@info.com"
                        };

                        userManager.CreateAsync(employee, AppSettings.EmployeePassword).GetAwaiter().GetResult();                      
                        userManager.CreateAsync(employeeTwo, AppSettings.ElectricianPassword).GetAwaiter().GetResult();
                        userManager.CreateAsync(company, AppSettings.CompanyPassword).GetAwaiter().GetResult();
                        userManager.CreateAsync(projectManager, AppSettings.ProjectManagerPassword).GetAwaiter().GetResult();


                        var projectManagerClaim = new Claim("Role", "ProjectManager");
                        var employeeTwoClaim = new Claim("Role", "Employee");
                        var employeeClaim = new Claim("Role", "Employee");
                        var companyClaim = new Claim("Role", "Company");

                        userManager.AddClaimAsync(projectManager, projectManagerClaim).GetAwaiter().GetResult();
                        userManager.AddClaimAsync(employeeTwo, employeeTwoClaim).GetAwaiter().GetResult();
                        userManager.AddClaimAsync(employee, employeeClaim).GetAwaiter().GetResult();
                        userManager.AddClaimAsync(company, companyClaim).GetAwaiter().GetResult();
                    
                        
                    
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
