using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Chat
{
    public class ScheduledMessageResponse : PostMessageResponse
    {
        [JsonProperty("post_at")]
        public long PostAt { get; set; }

        [JsonProperty("scheduled_message_id")]
        public string ScheduledMessageId { get; set; }
    }
}