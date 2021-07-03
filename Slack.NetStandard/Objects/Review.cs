using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slack.NetStandard.Objects
{
    public class Review
    {
        [JsonProperty("type",NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("date_review",NullValueHandling = NullValueHandling.Ignore)]
        public long? DateReview { get; set; }

        [JsonProperty("reviewing_team",NullValueHandling = NullValueHandling.Ignore)]
        public Team ReviewingTeam { get; set; }

        [JsonExtensionData]
        public Dictionary<string,object> OtherFields { get; set; }
    }
}