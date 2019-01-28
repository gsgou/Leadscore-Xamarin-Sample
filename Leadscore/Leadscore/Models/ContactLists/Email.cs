using Newtonsoft.Json;

namespace Leadscore.Models
{
    public class Email
    {
        [JsonProperty("primary", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Primary { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string EmailEmail { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("consentDetails", NullValueHandling = NullValueHandling.Ignore)]
        public ConsentDetails ConsentDetails { get; set; }
    }
}