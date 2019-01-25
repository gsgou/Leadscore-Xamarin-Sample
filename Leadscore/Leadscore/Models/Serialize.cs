using Newtonsoft.Json;

namespace Leadscore.Models
{
    public static class Serialize
    {
        public static string ToJson(this LoginResult self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}