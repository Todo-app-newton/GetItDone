using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GetItDone_Frontend.Models
{
    public class LoginUserModel
    {
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
