using Newtonsoft.Json;
using Slack.NetStandard.Messages;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class MessageCallbackEvent:Message,IMessageCallbackEvent
    {
        public const string EventType = "message";

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("event_ts", NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp EventTimestamp { get; set; }

        [JsonProperty("assistant_thread", NullValueHandling =NullValueHandling.Ignore)]
        public AssistantThread AssistantThread { get; set; }
    }
}