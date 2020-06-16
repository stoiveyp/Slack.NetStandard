using Newtonsoft.Json;
using Slack.NetStandard.EventsApi.CallbackEvents;
using Slack.NetStandard.Messages;

namespace Slack.NetStandard.WebApi.Chat
{
    public class PostMessageResponse:WebApiResponse
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("ts", NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp Timestamp { get; set; }

        [JsonProperty("message")]
        public Message Message { get; set; }
        
    }
}