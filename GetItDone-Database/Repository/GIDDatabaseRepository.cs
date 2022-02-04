using GetItDone_Database.Database;
using GetItDone_Models.Interfaces;
using GetItDone_Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GetItDone_Database.Repository
{
    public class GIDDatabaseRepository : ICustomerRepository
    {

        private readonly GIDDatabaseContext _context;
        public GIDDatabaseRepository(GIDDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Customer> CustomerAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer is null)
                return null;

            return customer;
        }

        public async Task<IEnumerable<Customer>> CustomersAsync() => await _context.Customers.AsNoTracking().ToListAsync();

        public Task DeleteCustomerAsync(int id)
        {
            var customer = CustomerAsync(id);
            _context.Remove(customer);
            return Task.CompletedTask;
        }

        public Task UpdateCustomerAsync(Customer customer)
        {
            _context.Attach(customer);
            _context.Entry(customer).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
