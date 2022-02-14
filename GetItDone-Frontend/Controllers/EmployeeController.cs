using GetItDone_Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GetItDone_Frontend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {


        [HttpPost]
        public async Task Post(int id)
        {
            if (ModelState.IsValid)
            {
                using (var _httpCLient = new HttpClient())
                {
                    var url = "api/employee/completeAssignment";
                    var serialized = JsonConvert.SerializeObject(id);
                    var content = new StringContent(serialized, Encoding.UTF8, "Application/json");
                    var response = await _httpCLient.PostAsync(url, content);
                }
            }
        }

        [HttpGet]
        public async Task<IEnumerable<AssignmentViewModel>> Get()
        {
            using(var _httpClient = new HttpClient())
            {
                var testEmail = "Paiter@Skanska.com";
                var requestUrl = "http://localhost:5000/api/Employee/Assignments/";

                var response = await _httpClient.GetAsync(requestUrl + testEmail);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync().Result;
                    var assignments = JsonConvert.DeserializeObject<IEnumerable<AssignmentViewModel>>(jsonString).ToArray();
                    return assignments;
                }              
            }
            return null;
        }
    }
}
