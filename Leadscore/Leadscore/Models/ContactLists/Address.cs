using Newtonsoft.Json;

namespace Leadscore.Models
{
    public class Address
    {
        [JsonProperty("fullAddress", NullValueHandling = NullValueHandling.Ignore)]
        public string FullAddress { get; set; }

        [JsonProperty("street", NullValueHandling = NullValueHandling.Ignore)]
        public string Street { get; set; }

        [JsonProperty("neighborhood", NullValueHandling = NullValueHandling.Ignore)]
        public string Neighborhood { get; set; }

        [JsonProperty("poBox", NullValueHandling = NullValueHandling.Ignore)]
        public string PoBox { get; set; }

        [JsonProperty("postCode", NullValueHandling = NullValueHandling.Ignore)]
        public string PostCode { get; set; }

        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }

        [JsonProperty("region", NullValueHandling = NullValueHandling.Ignore)]
        public string Region { get; set; }

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
    }
}