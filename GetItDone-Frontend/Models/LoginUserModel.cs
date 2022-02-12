using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GetItDone_Frontend.Models
{
    public class LoginUserModel
    {
        //[DataType(DataType.EmailAddress)]
        [JsonProperty("email")]
        public string Email { get; set; }

        //[DataType(DataType.Password)]
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
