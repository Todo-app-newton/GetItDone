using GetItDone_Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GetItDone_Models.Interfaces.Repository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> CustomersAsync();
        Task<Customer> CustomerAsync(int id);
        Task DeleteCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task CreateCustomerAsync(Customer customer);
        
    }
}
