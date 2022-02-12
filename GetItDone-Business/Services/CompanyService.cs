using GetItDone_Database.Repository;
using GetItDone_Models.Interfaces.Services;
using GetItDone_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetItDone_Business.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly GIDDatabaseRepository _databaseRepo;
        public CompanyService(GIDDatabaseRepository databaseRepo)
        {
            _databaseRepo = databaseRepo;
        }


        public bool CreateCompanyAsync(Company company)
        {
            try
            {
                return _databaseRepo.CreateCompanyAsync(company).IsCompletedSuccessfully;
            }
            catch (Exception)
            {
                //Implementing logger at later stage.
                throw;
            }
        }

        public async Task<bool> DeleteCompanyAsync(int id)
        {
            try
            {
                var company = await _databaseRepo.CompanyAsync(id);

                if (company is null) return false;

                return _databaseRepo.DeleteCompanyAsync(company).IsCompletedSuccessfully;
            }
            catch (Exception)
            {
                //Implementing logger at later stage.
                throw;
            }
        }

        public async Task<Company> GetCompanyAsync(int id)
        {
            try
            {
                var company = await _databaseRepo.CompanyAsync(id);

                if (company is null) return null;

                return company;

            }
            catch (Exception)
            {
                //Implementing logger at later stage.
                throw;
            }
        }

        public async Task<IEnumerable<Company>> GetCompanysAsync()
        {
            try
            {
                var companies = await _databaseRepo.CompanysAsync();

                if (companies.Any()) return companies;

                return null;
            }
            catch (Exception)
            {
                //Implementing logger at later stage.
                throw;
            }
        }

        public bool UpdateCompanyAsync(Company updateCompany)
        {
            try
            {

                return _databaseRepo.UpdateCompanyAsync(updateCompany).IsCompletedSuccessfully;
            }
            catch (Exception)
            {
                //Implementing logger at later stage.
                throw;
            }
        }
    }
}
