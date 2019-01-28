using Newtonsoft.Json;

namespace Leadscore.Models
{
    public class CustomField
    {
        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public ContactReferences Value { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("definitionId", NullValueHandling = NullValueHandling.Ignore)]
        public long? DefinitionId { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("references", NullValueHandling = NullValueHandling.Ignore)]
        public ContactReferences References { get; set; }

        [JsonProperty("readOnly", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ReadOnly { get; set; }
    }
}