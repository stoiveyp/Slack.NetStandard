using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slack.NetStandard.Objects
{
    public class Acceptance
    {
        [JsonProperty("approval_status",NullValueHandling = NullValueHandling.Ignore)]
        public string ApprovalStatus { get; set; }

        [JsonProperty("date_accepted",NullValueHandling = NullValueHandling.Ignore)]
        public long? DateAccepted { get; set; }

        [JsonProperty("date_invalid",NullValueHandling = NullValueHandling.Ignore)]
        public long? DateInvalid { get; set; }

        [JsonProperty("date_last_updated",NullValueHandling = NullValueHandling.Ignore)]
        public long? LastUpdated { get; set; }

        [JsonProperty("accepting_team",NullValueHandling = NullValueHandling.Ignore)]
        public Team AcceptingTeam { get; set; }

        [JsonProperty("accepting_user",NullValueHandling = NullValueHandling.Ignore)]
        public User AcceptingUser { get; set; }

        [JsonProperty("reviews",NullValueHandling = NullValueHandling.Ignore)]
        public Review[] Reviews { get; set; }

        [JsonExtensionData]
        public Dictionary<string,object> OtherFields { get; set; }
    }
}