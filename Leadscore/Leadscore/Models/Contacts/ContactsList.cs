using System.Collections.Generic;
using Newtonsoft.Json;

namespace Leadscore.Models
{
    public class ContactsList
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("mode", NullValueHandling = NullValueHandling.Ignore)]
        public string Mode { get; set; }

        [JsonProperty("dynamic", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Dynamic { get; set; }

        [JsonProperty("emailDistributionList", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EmailDistributionList { get; set; }

        [JsonProperty("startDate", NullValueHandling = NullValueHandling.Ignore)]
        public long? StartDate { get; set; }

        [JsonProperty("endDate", NullValueHandling = NullValueHandling.Ignore)]
        public long? EndDate { get; set; }

        [JsonProperty("contactsCount", NullValueHandling = NullValueHandling.Ignore)]
        public long? ContactsCount { get; set; }

        [JsonProperty("activeStatuses", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> ActiveStatuses { get; set; }

        [JsonProperty("inactiveStatuses", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> InactiveStatuses { get; set; }

        [JsonProperty("contacts", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Contact> Contacts { get; set; }

        [JsonProperty("lastInteraction", NullValueHandling = NullValueHandling.Ignore)]
        public LastInteraction LastInteraction { get; set; }

        [JsonProperty("completion", NullValueHandling = NullValueHandling.Ignore)]
        public long? Completion { get; set; }

        [JsonProperty("ownerId", NullValueHandling = NullValueHandling.Ignore)]
        public string OwnerId { get; set; }

        [JsonProperty("reviewers", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> Reviewers { get; set; }

        [JsonProperty("participants", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> Participants { get; set; }

        [JsonProperty("sharing", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Sharing> Sharing { get; set; }

        [JsonProperty("listTriggers", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<ListTrigger> ListTriggers { get; set; }
    }
}