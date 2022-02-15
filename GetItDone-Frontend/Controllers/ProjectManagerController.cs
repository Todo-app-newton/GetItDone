using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetItDone_Frontend.Controllers
{
    public class ProjectManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
