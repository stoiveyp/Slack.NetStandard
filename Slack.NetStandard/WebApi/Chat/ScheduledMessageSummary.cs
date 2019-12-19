using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Chat
{
    public class ScheduledMessageSummary
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("channel_id")]
        public string Channel { get; set; }

        [JsonProperty("post_at")]
        public long PostAt { get; set; }

        [JsonProperty("date_created")]
        public long DateCreated { get; set; }
    }
}