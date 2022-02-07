using GetItDone_Models.Interfaces.Services;
using GetItDone_Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GetItDone_Business.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly UserManager<IdentityUser> _userManager;
        public AuthenticationService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<string>> GetUserRole(string username)
        {
            var user = await _userManager.FindByEmailAsync(username);
            var roles = await _userManager.GetClaimsAsync(user);
            var newList = new List<string>();

            foreach (var role in roles.Select(x => x.Value))
            {
                newList.Add(role);
            }
            return newList;
        }

        public async Task<bool> EmailExists(string email)
        {
            return await _userManager.FindByEmailAsync(email) != null ? true : false;
        }

        public async Task<bool> IsValidUserCredentials(string username, string password)
        {
            var user = await _userManager.FindByEmailAsync(username);
            return await _userManager.CheckPasswordAsync(user, password);
        }


        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettings.SecretKey));
            var signInCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            return new JwtSecurityTokenHandler().WriteToken(
                new JwtSecurityToken(
                issuer: AppSettings.HostName,
                audience: AppSettings.HostName,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signInCredentials)
                );
        }
    }
}
