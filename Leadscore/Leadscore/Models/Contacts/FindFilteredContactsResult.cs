using System.Collections.Generic;
using Newtonsoft.Json;

namespace Leadscore.Models
{
    public class FindFilteredContactsResult
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Contact> Data { get; set; }

        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public long? Limit { get; set; }

        [JsonProperty("offset", NullValueHandling = NullValueHandling.Ignore)]
        public long? Offset { get; set; }

        [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
        public long? Count { get; set; }
    }
}