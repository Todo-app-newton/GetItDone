using GetItDone_Frontend.Helpers;
using GetItDone_Models.Models.Auth;
using GetItDone_Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GetItDone_Frontend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
     
        [HttpGet("Role")]
        public RoleViewModel GetLoggedInRole()
        {
            using (var _httpClient = new HttpClient())
            {
                var session = SessionHelper.GetObjectFromJson<LoginResponse>(HttpContext.Session, "identity");
                var returnSession = new RoleViewModel 
                {
                    Role = session.Roles.FirstOrDefault()
                }; 
                return returnSession;
            }
            return null;
        }
    }
}
