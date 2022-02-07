using GetItDone_Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetItDone_Database.Database
{
    public class GIDDatabaseContext : DbContext
    {
        public GIDDatabaseContext(DbContextOptions<GIDDatabaseContext> options) : base(options){}


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectManager> ProjectManagers { get; set; }
    }
}
