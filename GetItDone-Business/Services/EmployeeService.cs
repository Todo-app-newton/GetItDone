﻿using GetItDone_Database.Repository;
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
    public class EmployeeService : IEmployeeService
    {
        private readonly GIDDatabaseRepository _databaseRepo;
        public EmployeeService(GIDDatabaseRepository databaseRepo)
        {
            _databaseRepo = databaseRepo;
        }

        public bool CreateEmployeeAsync(Employee createEmployee)
        {
            try
            {
                var companyId = _databaseRepo.CompanyAsync(createEmployee.Id);

                var newEmployee = new Employee
                {
                    FirstName = createEmployee.FirstName,
                    LastName = createEmployee.LastName,
                    Email = createEmployee.Email,
                    Profession = createEmployee.Profession,
                    CompanyId = companyId.Id
                };

                return _databaseRepo.CreateEmployeeAsync(newEmployee).IsCompletedSuccessfully;
            }
            catch (Exception)
            {
                //Implementing logger at later stage.
                throw;
            }
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            try
            {
                var employee = await _databaseRepo.EmployeeAsync(id);

                if (employee is null) return false;

                return _databaseRepo.DeleteEmployeeAsync(employee).IsCompletedSuccessfully;
            }
            catch (Exception)
            {
                //Implementing logger at later stage.
                throw;
            }
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            try
            {
                var employee = await _databaseRepo.EmployeeAsync(id);

                if (employee is null) return null;

                return employee;

            }
            catch (Exception)
            {
                //Implementing logger at later stage.
                throw;
            }
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            try
            {
                var employees = await _databaseRepo.EmployeesAsync();

                if (employees.Any()) return employees;

                return null;
            }
            catch (Exception)
            {
                //Implementing logger at later stage.
                throw;
            }
        }

        public bool UpdateEmployeeAsync(Employee updateEmployee)
        {
            try
            {
                return _databaseRepo.UpdateEmployeeAsync(updateEmployee).IsCompletedSuccessfully;
            }
            catch (Exception)
            {
                //Implementing logger at later stage.
                throw;
            }
        }
    }
}
