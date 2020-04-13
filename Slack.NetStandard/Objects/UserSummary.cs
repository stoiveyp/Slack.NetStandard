using Newtonsoft.Json;

namespace Slack.NetStandard.Objects
{
    public class UserSummary
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("username", NullValueHandling = NullValueHandling.Ignore)]
        public string Username { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("team_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TeamId { get; set; }

        [JsonProperty("email",NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }
    }
}
