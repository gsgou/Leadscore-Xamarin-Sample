using Newtonsoft.Json;

namespace Leadscore.Models
{
    public class List
    {
        [JsonProperty("active", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Active { get; set; }

        [JsonProperty("currentStatus", NullValueHandling = NullValueHandling.Ignore)]
        public string CurrentStatus { get; set; }

        [JsonProperty("updated", NullValueHandling = NullValueHandling.Ignore)]
        public long? Updated { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("listId", NullValueHandling = NullValueHandling.Ignore)]
        public long? ListId { get; set; }
    }
}