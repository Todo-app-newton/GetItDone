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
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginUser()
        {
            Console.Write("Lalalala");
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
