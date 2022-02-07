using GetItDone_Database.Database;
using GetItDone_Models.Interfaces;
using GetItDone_Models.Interfaces.Repository;
using GetItDone_Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GetItDone_Database.Repository
{
    public class GIDDatabaseRepository : ICustomerRepository, IProjectManagerRepository, IEmployeeRepository, IAssignmentRepository
    {

        private readonly GIDDatabaseContext _context;
        public GIDDatabaseRepository(GIDDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Assignment> AssignmentAsync(int id)
        {
            var assignment = await _context.Assignments.FindAsync(id);

            if (assignment is null) return null;

            return assignment;
        }

        public async Task<IEnumerable<Assignment>> AssignmentsAsync() => await _context.Assignments.AsNoTracking().ToListAsync();

        public async Task<Customer> CustomerAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer is null)
                return null;

            return customer;
        }

        public async Task<IEnumerable<Customer>> CustomersAsync() => await _context.Customers.AsNoTracking().ToListAsync();

        public Task DeleteAssignmentAsync(int id)
        {
            var assignment = AssignmentAsync(id);
            _context.Remove(assignment);
            return Task.CompletedTask;
        }

        public Task DeleteCustomerAsync(int id)
        {
            var customer = CustomerAsync(id);
            _context.Remove(customer);
            return Task.CompletedTask;
        }

        public Task DeleteEmployeeAsync(int id)
        {
            var employee = EmployeeAsync(id);
            _context.Remove(employee);
            return Task.CompletedTask;
        }

        public Task DeleteProjectManagerAsync(int id)
        {
            var projectManager = ProjectManagerAsync(id);
            _context.Remove(projectManager);
            return Task.CompletedTask;
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
            var projectManager = await _context.ProjectManagers.FindAsync(id);

            if (projectManager is null) return null;

            return projectManager;
        }

        public async Task<IEnumerable<ProjectManager>> ProjectManagersAsync() => await _context.ProjectManagers.AsNoTracking().ToListAsync();

        public Task UpdateAssignmentAsync(Assignment assignment)
        {
            _context.Attach(assignment);
            _context.Entry(assignment).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public Task UpdateCustomerAsync(Customer customer)
        {
            _context.Attach(customer);
            _context.Entry(customer).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public Task UpdateEmployeeAsync(Employee employee)
        {
            _context.Attach(employee);
            _context.Entry(employee).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public Task UpdateProjectManagerAsync(ProjectManager projectManager)
        {
            _context.Attach(projectManager);
            _context.Entry(projectManager).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
