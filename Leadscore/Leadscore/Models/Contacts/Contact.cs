using System.Collections.Generic;
using Newtonsoft.Json;

namespace Leadscore.Models
{
    public class Contact
    {
        [JsonProperty("sharing", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Sharing> Sharing { get; set; }

        [JsonProperty("contactType", NullValueHandling = NullValueHandling.Ignore)]
        public string ContactType { get; set; }

        [JsonProperty("companyName", NullValueHandling = NullValueHandling.Ignore)]
        public string CompanyName { get; set; }

        [JsonProperty("enrich", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Enrich { get; set; }

        [JsonProperty("sfdcDuplicate", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SfdcDuplicate { get; set; }

        [JsonProperty("sfdcEnrich", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SfdcEnrich { get; set; }

        [JsonProperty("clientId", NullValueHandling = NullValueHandling.Ignore)]
        public string ClientId { get; set; }

        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get; set; }

        [JsonProperty("addresses", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Address> Addresses { get; set; }

        [JsonProperty("emails", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Email> Emails { get; set; }

        [JsonProperty("phoneNumbers", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }

        [JsonProperty("prefix", NullValueHandling = NullValueHandling.Ignore)]
        public string Prefix { get; set; }

        [JsonProperty("firstName", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName { get; set; }

        [JsonProperty("lastName", NullValueHandling = NullValueHandling.Ignore)]
        public string LastName { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("middleName", NullValueHandling = NullValueHandling.Ignore)]
        public string MiddleName { get; set; }

        [JsonProperty("suffix", NullValueHandling = NullValueHandling.Ignore)]
        public string Suffix { get; set; }

        [JsonProperty("salutation", NullValueHandling = NullValueHandling.Ignore)]
        public string Salutation { get; set; }

        [JsonProperty("gender", NullValueHandling = NullValueHandling.Ignore)]
        public string Gender { get; set; }

        [JsonProperty("restrictions", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> Restrictions { get; set; }

        [JsonProperty("assignedTo", NullValueHandling = NullValueHandling.Ignore)]
        public string AssignedTo { get; set; }

        [JsonProperty("websites", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Website> Websites { get; set; }

        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> Tags { get; set; }

        [JsonProperty("profiles", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Profile> Profiles { get; set; }

        [JsonProperty("lists", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<List> Lists { get; set; }

        [JsonProperty("profileUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string ProfileUrl { get; set; }

        [JsonProperty("metaRefs", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<MetaRef> MetaRefs { get; set; }

        [JsonProperty("customFields", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<CustomField> CustomFields { get; set; }

        [JsonProperty("segments", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Segment> Segments { get; set; }

        [JsonProperty("organizationId", NullValueHandling = NullValueHandling.Ignore)]
        public string OrganizationId { get; set; }

        [JsonProperty("creatorId", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatorId { get; set; }

        [JsonProperty("leadscore", NullValueHandling = NullValueHandling.Ignore)]
        public long? Leadscore { get; set; }

        [JsonProperty("displayName", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayName { get; set; }

        [JsonProperty("relatedTo", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<RelatedTo> RelatedTo { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("birthday", NullValueHandling = NullValueHandling.Ignore)]
        public string Birthday { get; set; }

        [JsonProperty("snoozedUntil", NullValueHandling = NullValueHandling.Ignore)]
        public long? SnoozedUntil { get; set; }

        [JsonProperty("nationality", NullValueHandling = NullValueHandling.Ignore)]
        public string Nationality { get; set; }

        [JsonProperty("locale", NullValueHandling = NullValueHandling.Ignore)]
        public string Locale { get; set; }

        [JsonProperty("pictures", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Picture> Pictures { get; set; }

        [JsonProperty("updated", NullValueHandling = NullValueHandling.Ignore)]
        public long? Updated { get; set; }

        [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        public long? Created { get; set; }

        [JsonProperty("profilePicture", NullValueHandling = NullValueHandling.Ignore)]
        public string ProfilePicture { get; set; }

        [JsonProperty("favorite", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Favorite { get; set; }
    }
}