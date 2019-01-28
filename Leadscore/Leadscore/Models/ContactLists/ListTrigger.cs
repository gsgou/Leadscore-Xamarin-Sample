using Newtonsoft.Json;

namespace Leadscore.Models
{
    public class ListTrigger
    {
        [JsonProperty("destinationListId", NullValueHandling = NullValueHandling.Ignore)]
        public long? DestinationListId { get; set; }

        [JsonProperty("triggerStatus", NullValueHandling = NullValueHandling.Ignore)]
        public string TriggerStatus { get; set; }
    }
}