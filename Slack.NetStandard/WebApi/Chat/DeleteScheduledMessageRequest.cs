using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Chat
{
    class DeleteScheduledMessageRequest
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("scheduled_message_id")]
        public string ScheduledMessageId { get; set; }

        [JsonProperty("as_user", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AsUser { get; set; }
    }
}