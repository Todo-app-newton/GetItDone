using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetItDone_Models.ViewModels
{
    public class AssignmentViewModelEdit
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("period")]
        public DateTime Period { get; set; }

        [JsonProperty("progress")]
        public string Progress { get; set; }
    }
}
