using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Chat
{
    public class ScheduledMessageListResponse:WebApiResponse<ResponseMetadata>
    {
        [JsonProperty("scheduled_messages")]
        public ScheduledMessageSummary[] ScheduledMessages { get; set; }
    }
}
