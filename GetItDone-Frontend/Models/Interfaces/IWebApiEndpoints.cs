using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetItDone_Frontend.Models.Interfaces
{
    interface IWebApiEndpoints
    {
        public string LoginUser { get; }
        public string GetToken { get; }
    }
}
