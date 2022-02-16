using GetItDone_Frontend.Helpers;
using GetItDone_Frontend.Models;
using GetItDone_Models.Models;
using GetItDone_Models.Models.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GetItDone_Frontend.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly WebApiEndpoints endpoints;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
            endpoints = new WebApiEndpoints();
        }
        [HttpPost("employeebyemail")]
        public async Task<Employee> EmployeeByEmail([FromBody] EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                var employeeRequest = new Employee()
                {
                    Email = employee.Email
                };
                using (var _httpClient = new HttpClient())
                {
                    var session = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "identity");
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session.Token);

                    var userEmail = JsonConvert.SerializeObject(employeeRequest.Email);
                    var content = new StringContent(userEmail, Encoding.UTF8, "Application/json");

                    var requestUrl = "https://localhost:5001/api/EmployeeEmail/";

                    var response = await _httpClient.PostAsync(requestUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        var jsonString = JsonConvert.DeserializeObject<Employee>(result);
                        return jsonString;
                    }
                }

                return null;
            }
            return null;
        }
    }
}
