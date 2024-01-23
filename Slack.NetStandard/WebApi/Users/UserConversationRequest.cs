using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Users
{
    public class UserConversationRequest
    {
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; set; }

        [JsonProperty("exclude_archived", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ExcludeArchived { get; set; }

        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; set; }

        [JsonProperty("types", NullValueHandling = NullValueHandling.Ignore)]
        public string Types { get; set; }

        [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }

        [JsonProperty("team_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TeamId { get; set; }
    }
}
