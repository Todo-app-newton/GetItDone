using GetItDone_Models.Interfaces.Services;
using GetItDone_Models.Models;
using GetItDone_Models.Models.Auth;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GetItDone_Backend.Controllers
{

    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly IAuthenticationService _authService;
        public AuthenticationController(IAuthenticationService authService)
        {
            _authService = authService;
        }


        [HttpPost]
        [Route("api/Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {

            if (request is null) return BadRequest("Invalid request");

            if(await _authService.EmailExists(request.Email))
            {
                var validation = await _authService.IsValidUserCredentials(request.Email, request.Password);

                if (validation)
                {
                    var userRoles = await _authService.GetUserRole(request.Email);

                    var roles = new List<string>();
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, request.Email)
                };

                    foreach (var claim in userRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, claim));
                        roles.Add(claim);
                    }

                    var accessToken = _authService.GenerateAccessToken(claims);

                    return Ok(new LoginResponse
                    {
                        Token = accessToken,
                        Roles = roles,
                        IsLoggedIn = true
                    });
                }
                return BadRequest("Something happen, try again!");
            }

            return NotFound("No account exists with that email, try again!");
        }
    }
}
