using Newtonsoft.Json;

namespace Leadscore.Models
{
    public class ConsentDetails
    {
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("received", NullValueHandling = NullValueHandling.Ignore)]
        public long? Received { get; set; }

        [JsonProperty("ipAddress", NullValueHandling = NullValueHandling.Ignore)]
        public string IpAddress { get; set; }
    }
}