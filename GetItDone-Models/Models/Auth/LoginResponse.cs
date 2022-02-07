using System;
using System.Collections.Generic;
using System.Text;

namespace GetItDone_Models.Models.Auth
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public bool IsLoggedIn { get; set; }
    }
}
