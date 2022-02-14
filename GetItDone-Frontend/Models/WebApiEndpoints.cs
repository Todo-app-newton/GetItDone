using GetItDone_Frontend.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetItDone_Frontend.Models
{
    public class WebApiEndpoints : IWebApiEndpoints
    {
        private string HostName => "https://localhost:5001/";

        public string LoginUser => HostName + "api/Login";

        public string GetToken => throw new NotImplementedException();
    }
}
