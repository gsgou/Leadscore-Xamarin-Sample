using System.Collections.Generic;
using Newtonsoft.Json;

namespace Leadscore.Models
{
    public class FindFilteredContactsRequest
    {
        [JsonProperty("defaultOperator", NullValueHandling = NullValueHandling.Ignore)]
        public string DefaultOperator { get; set; }

        [JsonProperty("filters", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Filter> Filters { get; set; }
    }
}