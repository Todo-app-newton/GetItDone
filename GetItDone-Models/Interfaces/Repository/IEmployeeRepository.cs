using GetItDone_Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GetItDone_Models.Interfaces.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> EmployeesAsync();
        Task<Employee> EmployeeAsync(int id);
        Task DeleteEmployeeAsync(int id);
        Task UpdateEmployeeAsync(Employee employee);
    }
}
