using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin
{
    public class CreateConversationRequest
    {
        [JsonProperty("is_private")]
        public bool IsPrivate { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description",NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("org_wide",NullValueHandling = NullValueHandling.Ignore)]
        public bool? OrgWide { get; set; }

        [JsonProperty("team_id",NullValueHandling = NullValueHandling.Ignore)]
        public string TeamId { get; set; }
    }
}
