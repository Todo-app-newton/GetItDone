using GetItDone_Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GetItDone_Models.Interfaces.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetCompanysAsync();
        bool CreateCompanyAsync(Company company);
        Task<Company> GetCompanyAsync(int id);
        Task<bool> DeleteCompanyAsync(int id);
        bool UpdateCompanyAsync(Company updateCompany);
    }
}
