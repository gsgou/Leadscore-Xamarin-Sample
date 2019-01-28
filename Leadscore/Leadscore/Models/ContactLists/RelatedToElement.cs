using System.Collections.Generic;
using Newtonsoft.Json;

namespace Leadscore.Models
{
    public class RelatedToElement
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("displayName", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayName { get; set; }

        [JsonProperty("companyName", NullValueHandling = NullValueHandling.Ignore)]
        public string CompanyName { get; set; }

        [JsonProperty("companyId", NullValueHandling = NullValueHandling.Ignore)]
        public string CompanyId { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("creatorId", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatorId { get; set; }

        [JsonProperty("sharing", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Sharing> Sharing { get; set; }

        [JsonProperty("profilePicture", NullValueHandling = NullValueHandling.Ignore)]
        public string ProfilePicture { get; set; }
    }
}