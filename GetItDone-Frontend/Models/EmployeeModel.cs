using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetItDone_Frontend.Models
{
    public class EmployeeModel
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("profession")]
        public string Profession { get; set; }
        [JsonProperty("company")]
        public string Company { get; set; }
    }
}
