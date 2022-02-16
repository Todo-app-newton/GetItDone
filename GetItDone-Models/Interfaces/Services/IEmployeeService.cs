using GetItDone_Models.DTO;
using GetItDone_Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GetItDone_Models.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<bool> CreateEmployeeAsync(Employee createEmployee);
        Task<Employee> GetEmployeeAsync(int id);
        Task<bool> DeleteEmployeeAsync(int id);
        bool UpdateEmployeeAsync(Employee updateEmployee);
        Task<IEnumerable<Assignment>> GetAllEmployeeAssignments(string email);
    }
}
