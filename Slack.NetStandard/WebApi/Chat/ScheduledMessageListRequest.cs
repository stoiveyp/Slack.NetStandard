using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Chat
{
    public class ScheduledMessageListRequest
    {
        [JsonProperty("channel", NullValueHandling = NullValueHandling.Ignore)]
        public string Channel { get; set; }

        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; set; }

        [JsonProperty("latest", NullValueHandling = NullValueHandling.Ignore)]
        public long? Latest { get; set; }

        [JsonProperty("oldest", NullValueHandling = NullValueHandling.Ignore)]
        public long? Oldest { get; set; }

        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; set; }

        [JsonProperty("team_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? TeamId { get; set; }
    }
}