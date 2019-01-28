using System.Collections.Generic;
using Newtonsoft.Json;

namespace Leadscore.Models
{
    public class User
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("username", NullValueHandling = NullValueHandling.Ignore)]
        public string Username { get; set; }

        [JsonProperty("accountStatus", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountStatus { get; set; }

        [JsonProperty("expirationDate", NullValueHandling = NullValueHandling.Ignore)]
        public long? ExpirationDate { get; set; }

        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty("firstName", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName { get; set; }

        [JsonProperty("lastName", NullValueHandling = NullValueHandling.Ignore)]
        public string LastName { get; set; }

        [JsonProperty("phoneNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string PhoneNumber { get; set; }

        [JsonProperty("timeZone", NullValueHandling = NullValueHandling.Ignore)]
        public string TimeZone { get; set; }

        [JsonProperty("organizationId", NullValueHandling = NullValueHandling.Ignore)]
        public string OrganizationId { get; set; }

        [JsonProperty("organizationName", NullValueHandling = NullValueHandling.Ignore)]
        public string OrganizationName { get; set; }

        [JsonProperty("signupClient", NullValueHandling = NullValueHandling.Ignore)]
        public string SignupClient { get; set; }

        [JsonProperty("dateCreated", NullValueHandling = NullValueHandling.Ignore)]
        public long? DateCreated { get; set; }

        [JsonProperty("lastLoginDate", NullValueHandling = NullValueHandling.Ignore)]
        public long? LastLoginDate { get; set; }

        [JsonProperty("active", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Active { get; set; }

        [JsonProperty("human", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Human { get; set; }

        [JsonProperty("permissions", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> Permissions { get; set; }

        [JsonProperty("teamIds", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> TeamIds { get; set; }

        [JsonProperty("partnerId", NullValueHandling = NullValueHandling.Ignore)]
        public string PartnerId { get; set; }

        [JsonProperty("profilePicture", NullValueHandling = NullValueHandling.Ignore)]
        public string ProfilePicture { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("alias", NullValueHandling = NullValueHandling.Ignore)]
        public string Alias { get; set; }

        [JsonProperty("instagramProfileId", NullValueHandling = NullValueHandling.Ignore)]
        public string InstagramProfileId { get; set; }
    }
}