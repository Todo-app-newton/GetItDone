using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetItDone_Models.ViewModels
{
   public class AssignmentsIdViewModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
