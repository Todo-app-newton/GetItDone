using GetItDone_Frontend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetItDone_Frontend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IEnumerable<LoginUserModel> Post(string values)
        {
            Console.Write("ladda "+values);
            return Enumerable.Range(1, 5).Select(index => new LoginUserModel
            {
                UserEmail = "value",
                Password = values

            })
            .ToArray();

        }
    }
}
