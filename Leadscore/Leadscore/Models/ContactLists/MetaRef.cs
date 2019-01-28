using Newtonsoft.Json;

namespace Leadscore.Models
{
    public class MetaRef
    {
        [JsonProperty("systemId", NullValueHandling = NullValueHandling.Ignore)]
        public string SystemId { get; set; }

        [JsonProperty("systemURL", NullValueHandling = NullValueHandling.Ignore)]
        public string SystemUrl { get; set; }

        [JsonProperty("entityId", NullValueHandling = NullValueHandling.Ignore)]
        public string EntityId { get; set; }

        [JsonProperty("entityName", NullValueHandling = NullValueHandling.Ignore)]
        public string EntityName { get; set; }
    }
}