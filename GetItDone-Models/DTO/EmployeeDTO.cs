using GetItDone_Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetItDone_Models.DTO
{
    public class EmployeeDTO
    {
        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("profession")]
        public string Profession { get; set; }

        [JsonProperty("companyid")]
        public string CompanyId { get; set; }


        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
