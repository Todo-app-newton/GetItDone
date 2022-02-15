using GetItDone_Frontend.Helpers;
using GetItDone_Models.Enums;
using GetItDone_Models.Models.Auth;
using GetItDone_Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
    public class AssignmentController : ControllerBase
    {
        private static string Url => "https://localhost:5001/api/Assignments/";


        [HttpPost("Complete")]
        public async Task Complete([FromBody] AssignmentsIdViewModel assignmentsIdViewModel)
        {
            if (ModelState.IsValid)
            {
                using (var _httpCLient = new HttpClient())
                {
                    var url = Url + "completeAssignment";
                    var session = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "identity");
                    _httpCLient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session.Token);
                    var serialized = JsonConvert.SerializeObject(assignmentsIdViewModel);
                    var content = new StringContent(serialized, Encoding.UTF8, "application/json");
                    var response = await _httpCLient.PostAsync(url, content);
                }
            }
        }

        [HttpPut("UpdateAssignment")]
        public async Task UpdateAssignment([FromBody] AssignmentViewModelEdit assignmentViewModelEdit)
        {
            if (ModelState.IsValid)
            {
                using (var _httpClient = new HttpClient())
                {
                    var session = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "identity");
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session.Token);
                    var serialized = JsonConvert.SerializeObject(assignmentViewModelEdit);
                    var content = new StringContent(serialized, Encoding.UTF8, "application/json");
                    var response = await _httpClient.PutAsync(Url, content);
                }
            }
        }


        [HttpPost("Start")]
        public async Task Start([FromBody] AssignmentsIdViewModel assignmentsIdViewModel)
        {
            if (ModelState.IsValid)
            {
                using (var _httpCLient = new HttpClient())
                {
                    var url = Url + "startAssignment";
                    var session = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "identity");
                    _httpCLient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session.Token);
                    var serialized = JsonConvert.SerializeObject(assignmentsIdViewModel);
                    var content = new StringContent(serialized, Encoding.UTF8, "application/json");
                    var response = await _httpCLient.PostAsync(url, content);
                }
            }
        }

        [HttpGet("FetchStarted")]
        public async Task<IEnumerable<AssignmentViewModel>> FetchStarted()
        {
            using(var _httpClient = new HttpClient())
            {
                var session = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "identity");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session.Token);
                var response = await _httpClient.GetAsync(Url + session.Email);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync().Result;
                    var assignments = JsonConvert.DeserializeObject<IEnumerable<AssignmentViewModel>>(jsonString).ToArray();

                    var onlyStartedAssignmenst = assignments.Where(x => x.Progress == Progress.Started.ToString());
                    return onlyStartedAssignmenst;
                }              
            }
            return null;
        }

        [HttpGet("FetchPending")]
        public async Task<IEnumerable<AssignmentViewModel>> FetchPending()
        {
            using (var _httpClient = new HttpClient())
            {
                var session = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "identity");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session.Token);

                var response = await _httpClient.GetAsync(Url + session.Email);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync().Result;
                    var assignments = JsonConvert.DeserializeObject<IEnumerable<AssignmentViewModel>>(jsonString).ToArray();

                    var onlyPendingAssignments = assignments.Where(x => x.Progress == Progress.Pending.ToString());
                    return onlyPendingAssignments;
                }
            }
            return null;
        }

        [HttpGet("FetchCompleted")]
        public async Task<IEnumerable<AssignmentViewModel>> FetchCompleted()
        {
            using (var _httpClient = new HttpClient())
            {
                var session = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "identity");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session.Token);
                var requestUrl = Url + "Assignments/";

                var response = await _httpClient.GetAsync(Url + session.Email);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync().Result;
                    var assignments = JsonConvert.DeserializeObject<IEnumerable<AssignmentViewModel>>(jsonString).ToArray();

                    var onlyCompletedAssignments = assignments.Where(x => x.Progress == Progress.Completed.ToString());
                    return onlyCompletedAssignments;
                }
            }
            return null;
        }
    }
}
