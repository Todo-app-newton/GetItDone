using GetItDone_Models.DTO;
using GetItDone_Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GetItDone_Models.Interfaces.Services
{
    public interface ICustomerService
    {

        Task<IEnumerable<Customer>> GetCustomersAsync();
        bool CreateCustomerAsync(Customer createCustomer);
        Task<Customer> GetCustomerAsync(int id);
        Task<bool> DeleteCustomerAsync(int id);
        bool UpdateCustomerAsync(Customer updateAssignment);
    }
}
