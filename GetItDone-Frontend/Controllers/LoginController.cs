using GetItDone_Frontend.Helpers;
using GetItDone_Frontend.Models;
using GetItDone_Models.Models;
using GetItDone_Models.Models.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GetItDone_Frontend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly WebApiEndpoints endpoints;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
            endpoints = new WebApiEndpoints();
        }

        [HttpPost]
        public async Task<LoginResponse> Post([FromBody]LoginUserModel login)
        {
            if (ModelState.IsValid)
            {
                var newLoginRequest = new LoginRequest()
                {
                    Email = login.Email,
                    Password = login.Password

                };
                var response = await GetToken(newLoginRequest);

                var identity = new LoginResponse
                {
                    Email = login.Email,
                    Token = response.Token,
                    IsLoggedIn = response.IsLoggedIn,
                    Roles = response.Roles
                };

                SessionHelper.SetObjectAsJson(HttpContext.Session, "identity", identity);

                return identity;
            }
            return null;
        }


        private async Task<LoginResponse> GetToken(LoginRequest request)
        {
            using (var _httpClient = new HttpClient())
            {
                var loginValue = JsonConvert.SerializeObject(request);
                var content = new StringContent(loginValue, Encoding.UTF8, "Application/json");
                var requestUrl = "https://localhost:5001/api/Login";

                var response = await _httpClient.PostAsync(requestUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    var jsonString = JsonConvert.DeserializeObject<LoginResponse>(result);
                    return jsonString;
                }
            }
            return null;
        }
    }
}
