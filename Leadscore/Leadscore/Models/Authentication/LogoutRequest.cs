using Newtonsoft.Json;

namespace Leadscore.Models
{
    public class LogoutRequest
    {
        [JsonProperty("authToken", NullValueHandling = NullValueHandling.Ignore)]
        public string AuthToken { get; set; }
    }
}