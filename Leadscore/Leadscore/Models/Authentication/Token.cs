using Newtonsoft.Json;

namespace Leadscore.Models
{
    public class Token
    {
        [JsonProperty("expires", NullValueHandling = NullValueHandling.Ignore)]
        public long? Expires { get; set; }

        [JsonProperty("authToken", NullValueHandling = NullValueHandling.Ignore)]
        public string AuthToken { get; set; }
    }
}