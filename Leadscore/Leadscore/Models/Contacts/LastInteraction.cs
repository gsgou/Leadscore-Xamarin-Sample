using System.Collections.Generic;
using Newtonsoft.Json;

namespace Leadscore.Models
{
    public class LastInteraction
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
        public References Metadata { get; set; }

        [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        public long? Created { get; set; }

        [JsonProperty("updated", NullValueHandling = NullValueHandling.Ignore)]
        public long? Updated { get; set; }

        [JsonProperty("direction", NullValueHandling = NullValueHandling.Ignore)]
        public string Direction { get; set; }

        [JsonProperty("contacts", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<RelatedTo> Contacts { get; set; }

        [JsonProperty("contactReferences", NullValueHandling = NullValueHandling.Ignore)]
        public References ContactReferences { get; set; }

        [JsonProperty("userId", NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }

        [JsonProperty("conflict", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Conflict { get; set; }

        [JsonProperty("conflicts", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> Conflicts { get; set; }

        [JsonProperty("unresolvedTo", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> UnresolvedTo { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("from", NullValueHandling = NullValueHandling.Ignore)]
        public string From { get; set; }

        [JsonProperty("to", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> To { get; set; }

        [JsonProperty("threadId", NullValueHandling = NullValueHandling.Ignore)]
        public string ThreadId { get; set; }

        [JsonProperty("listId", NullValueHandling = NullValueHandling.Ignore)]
        public long? ListId { get; set; }

        [JsonProperty("campaignId", NullValueHandling = NullValueHandling.Ignore)]
        public string CampaignId { get; set; }

        [JsonProperty("stepId", NullValueHandling = NullValueHandling.Ignore)]
        public string StepId { get; set; }

        [JsonProperty("threadPosition", NullValueHandling = NullValueHandling.Ignore)]
        public long? ThreadPosition { get; set; }

        [JsonProperty("metaRefs", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<MetaRef> MetaRefs { get; set; }

        [JsonProperty("segmentId", NullValueHandling = NullValueHandling.Ignore)]
        public long? SegmentId { get; set; }

        [JsonProperty("visibleTo", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Sharing> VisibleTo { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public References Status { get; set; }
    }
}