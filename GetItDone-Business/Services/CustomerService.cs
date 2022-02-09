using GetItDone_Database.Repository;
using GetItDone_Models.DTO;
using GetItDone_Models.Interfaces.Services;
using GetItDone_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetItDone_Business.Services
{
   public  class CustomerService : ICustomerService
    {
        private readonly GIDDatabaseRepository _databaseRepo;
        public CustomerService(GIDDatabaseRepository databaseRepo)
        {
            _databaseRepo = databaseRepo;
        }

        public bool CreateCustomerAsync(Customer createCustomer)
        {
            try
            {
                return _databaseRepo.CreateCustomerAsync(createCustomer).IsCompletedSuccessfully;
            }
            catch (Exception)
            {
                //Implementing logger at later stage.
                throw;
            }
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            try
            {
                var customer = await _databaseRepo.CustomerAsync(id);

                if (customer is null) return false;

                return _databaseRepo.DeleteCustomerAsync(customer).IsCompletedSuccessfully;
            }
            catch (Exception)
            {
                //Implementing logger at later stage.
                throw;
            }
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            try
            {
                var customer = await _databaseRepo.CustomerAsync(id);

                if (customer is null) return null;

                return customer;

            }
            catch (Exception)
            {
                //Implementing logger at later stage.
                throw;
            }
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            try
            {
                var customers = await _databaseRepo.CustomersAsync();

                if (customers.Any()) return customers;

                return null;
            }
            catch (Exception)
            {
                //Implementing logger at later stage.
                throw;
            }
        }

        public bool UpdateCustomerAsync(Customer updateAssignment)
        {
            try
            {

                return _databaseRepo.UpdateCustomerAsync(updateAssignment).IsCompletedSuccessfully;
            }
            catch (Exception)
            {
                //Implementing logger at later stage.
                throw;
            }
        }
    }
}
