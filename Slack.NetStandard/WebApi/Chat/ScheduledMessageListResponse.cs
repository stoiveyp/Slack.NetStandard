using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Chat
{
    public class ScheduledMessageListResponse:WebApiResponse
    {
        [JsonProperty("scheduled_messages")]
        public ScheduledMessageSummary[] ScheduledMessages { get; set; }

        [JsonProperty("response_metadata")]
        public ResponseMetadata Metadata { get; set; }
    }
}
