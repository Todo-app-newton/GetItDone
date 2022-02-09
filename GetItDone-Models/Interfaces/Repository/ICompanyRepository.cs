using GetItDone_Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GetItDone_Models.Interfaces.Repository
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> CompanysAsync();
        Task CreateCompanyAsync(Company company);
        Task<Company> CompanyAsync(int id);
        Task DeleteCompanyAsync(Company company);
        Task UpdateCompanyAsync(Company company);
    }
}
