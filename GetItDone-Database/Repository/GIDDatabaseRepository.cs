using GetItDone_Database.Database;
using GetItDone_Models.Interfaces;
using GetItDone_Models.Interfaces.Repository;
using GetItDone_Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetItDone_Database.Repository
{
    public class GIDDatabaseRepository : ICustomerRepository, IProjectManagerRepository,
        IEmployeeRepository, IAssignmentRepository, ICompanyRepository, IProjectRepository
    {

        private readonly GIDDatabaseContext _context;
        public GIDDatabaseRepository(GIDDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Assignment> AssignmentAsync(int id)
        {
            var assignment = await _context.Assignments.Where(x => x.Id == id).AsNoTracking().SingleOrDefaultAsync();

            if (assignment is null) return null;

            return assignment;
        }

        public async Task<IEnumerable<Assignment>> AssignmentsAsync() => await _context.Assignments.AsNoTracking().ToListAsync();

        public async Task<IEnumerable<Company>> CompanysAsync() => await _context.Companies.AsNoTracking().ToListAsync();
        

        public async Task<Company> CompanyAsync(int id)
        {
            var company = await _context.Companies.FindAsync(id);

            if (company is null) return null;

            return company;
        }

        public Task CreateAssignmenAsync(Assignment assignment)
        {
            _context.Add(assignment);
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public Task CreateCompanyAsync(Company company)
        {
            _context.Add(company);
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public Task CreateCustomerAsync(Customer customer)
        {
            _context.Add(customer);
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public Task CreateEmployeeAsync(Employee employee)
        {
            _context.Add(employee);
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public Task CreateProjectManager(ProjectManager projectManager)
        {
            _context.Add(projectManager);
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public async Task<Customer> CustomerAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer is null)
                return null;

            return customer;
        }

        public async Task<IEnumerable<Customer>> CustomersAsync() => await _context.Customers.AsNoTracking().ToListAsync();

        public Task DeleteAssignmentAsync(Assignment assignment)
        {
            _context.Remove(assignment);
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public Task DeleteCompanyAsync(Company company)
        {
            _context.Remove(company);
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public Task DeleteCustomerAsync(Customer customer)
        {
            _context.Remove(customer);
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public Task DeleteEmployeeAsync(Employee employee)
        {
            _context.Remove(employee);
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public Task DeleteProjectManagerAsync(ProjectManager projectManager)
        {
            try
            {
            _context.Remove(projectManager);
            _context.SaveChangesAsync();
            return Task.CompletedTask;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Employee> EmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee is null) return null;

            return employee;
        }

        public async Task<IEnumerable<Employee>> EmployeesAsync() => await _context.Employees.AsNoTracking().ToListAsync();

        public async Task<ProjectManager> ProjectManagerAsync(int id)
        {
            var projectManager = await _context.ProjectManagers.Where(x => x.Id == id).AsNoTracking().SingleOrDefaultAsync();

            if (projectManager is null) return null;

            return projectManager;
        }

        public async Task<IEnumerable<ProjectManager>> ProjectManagersAsync() => await _context.ProjectManagers.AsNoTracking().ToListAsync();

        public  Task UpdateAssignmentAsync(Assignment assignment)
        {
            try
            {
            _context.Update(assignment);
            _context.SaveChangesAsync();
            return Task.CompletedTask;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task UpdateCompanyAsync(Company company)
        {
            _context.Update(company);
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public Task UpdateCustomerAsync(Customer customer)
        {
            _context.Update(customer);
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public Task UpdateEmployeeAsync(Employee employee)
        {
            try
            {
                _context.Update(employee);
                _context.SaveChangesAsync();
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task UpdateProjectManagerAsync(ProjectManager projectManager)
        {
            try
            {
            _context.Update(projectManager);
            _context.SaveChangesAsync();
            return Task.CompletedTask;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<Project>> ProjectsAsync() => await _context.Projects.AsNoTracking().ToListAsync();

        public async Task<Project> ProjectAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project is null) return null;

            return project;
        }

        public Task CreateProject(Project project)
        {
            _context.Add(project);
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public Task DeleteProjectAsync(Project project)
        {
            _context.Remove(project);
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public Task UpdateProjectAsync(Project project)
        {
            _context.Update(project);
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public async Task<Employee> GetEmployeeByEmail(string email)
        {
            var employee = await _context.Employees.Where(x => x.Email == email).AsNoTracking().SingleAsync();

            if (employee is null) return null;

            return employee;
        }
    }
}
