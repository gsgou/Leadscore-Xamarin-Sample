using Newtonsoft.Json;

namespace Leadscore.Models
{
    public class Profile
    {
        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        [JsonProperty("username", NullValueHandling = NullValueHandling.Ignore)]
        public string Username { get; set; }

        [JsonProperty("avatarUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string AvatarUrl { get; set; }
    }
}