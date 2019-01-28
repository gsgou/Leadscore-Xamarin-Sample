using Newtonsoft.Json;

namespace Leadscore.Models
{
    public class Filter
    {
        [JsonProperty("field", NullValueHandling = NullValueHandling.Ignore)]
        public string Field { get; set; }

        [JsonProperty("op", NullValueHandling = NullValueHandling.Ignore)]
        public string Op { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }
    }
}