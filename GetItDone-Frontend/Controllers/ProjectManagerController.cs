using GetItDone_Frontend.Helpers;
using GetItDone_Frontend.Models;
using GetItDone_Models.DTO;
using GetItDone_Models.Models.Auth;
using GetItDone_Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
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
    [Route("api/[controller]")]
    public class ProjectManagerController : Controller
    {
        private static string Url => "https://localhost:5001/api/ProjectManager/";
        private static string empURL => "https://localhost:5001/api/employee/";
           
        [HttpGet("ProjectManagersName")]
        public async Task<ProjectManagerViewModel> GetProjectManagersName()
        {
            using (var _httpCLient = new HttpClient())
            {
                var projectManagersName = "ByEmail/";
                var session = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "identity");
                _httpCLient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session.Token);
                var response = await _httpCLient.GetAsync(Url + projectManagersName + session.Email);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync().Result;
                    var projectManagerViewModel = JsonConvert.DeserializeObject<ProjectManagerViewModel>(jsonString);
                    return projectManagerViewModel;
                }
            }
                return null;
        }

        [HttpGet("ProjectManagersProfile")]
        public async Task<ProfileModel> GetProjectManagersProfile()
        {
            using (var _httpCLient = new HttpClient())
            {
                var projectManagersName = "ByEmail/";
                var session = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "identity");
                _httpCLient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session.Token);
                var role = session.Roles.FirstOrDefault();
                
                if ( role == "ProjectManager")
                {
                    var response = await _httpCLient.GetAsync(Url + projectManagersName + session.Email);
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = response.Content.ReadAsStringAsync().Result;
                        var projectManagerViewModel = JsonConvert.DeserializeObject<ProjectManagerViewModel>(jsonString);

                        var managerProfile = new ProfileModel
                        {
                            FirstName = projectManagerViewModel.FirstName,
                            LastName = projectManagerViewModel.LastName,
                            Phone = projectManagerViewModel.PhoneNumber,
                            Email = session.Email,
                            Role =role
                            
                        };
                        return managerProfile;
                    }
                }
                else
                {
                    var response = await _httpCLient.GetAsync(empURL + projectManagersName + session.Email);
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = response.Content.ReadAsStringAsync().Result;
                        var employeeDTO = JsonConvert.DeserializeObject<EmployeeDTO>(jsonString);

                        var employeeProfile = new ProfileModel
                        {
                            FirstName = employeeDTO.FirstName,
                            LastName = employeeDTO.LastName,
                            Email = employeeDTO.Email,
                            Role = role,
                            Profession = employeeDTO.Profession,
                            Company = employeeDTO.CompanyId

                        };
                        return employeeProfile;
                    }
                }

            }
            return null;
        }

        [HttpPost("CreateEmployee")]
        public async Task<string> CreateEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            if (ModelState.IsValid)
            {
                using (var _httpCLient = new HttpClient())
                {
                    var url = "https://localhost:5001/api/employee";
                    var session = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "identity");
                    _httpCLient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session.Token);
                    var serialized = JsonConvert.SerializeObject(employeeDTO);
                    var content = new StringContent(serialized, Encoding.UTF8, "application/json");
                    var response = await _httpCLient.PostAsync(url, content);
                    if (response.IsSuccessStatusCode)
                    {
                        return response.Content.ReadAsStringAsync().Result;
                        
                    }
                }
            }
                return null;
        }

    }
}
