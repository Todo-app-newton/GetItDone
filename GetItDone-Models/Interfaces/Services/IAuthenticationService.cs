using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GetItDone_Models.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<bool> IsValidUserCredentials(string email, string password);
        Task<List<string>> GetUserRole(string username);
        Task<bool> EmailExists(string email); 
        string GenerateAccessToken(IEnumerable<Claim> claims);
    }
}
