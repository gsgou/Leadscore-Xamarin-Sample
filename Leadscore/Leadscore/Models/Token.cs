using System;
using Newtonsoft.Json;

namespace Leadscore.Models
{
    public partial class Token
    {
        [JsonProperty("expires", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? Expires { get; set; }

        [JsonProperty("authToken", NullValueHandling = NullValueHandling.Ignore)]
        public string AuthToken { get; set; }
    }
}