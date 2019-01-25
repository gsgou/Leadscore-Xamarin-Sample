using Newtonsoft.Json;

namespace Leadscore.Models
{
    public partial class LoginResult
    {
        [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
        public User User { get; set; }

        [JsonProperty("integrations", NullValueHandling = NullValueHandling.Ignore)]
        public Integrations Integrations { get; set; }

        [JsonProperty("firebaseAuthToken", NullValueHandling = NullValueHandling.Ignore)]
        public string FirebaseAuthToken { get; set; }

        [JsonProperty("token", NullValueHandling = NullValueHandling.Ignore)]
        public Token Token { get; set; }

        public static LoginResult FromJson(string json) => JsonConvert.DeserializeObject<LoginResult>(json, Converter.Settings);
    }
}