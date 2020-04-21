using System.Collections.Generic;
using Newtonsoft.Json;
using Slack.NetStandard.Messages;
using Slack.NetStandard.Messages.Blocks;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class MessageCallbackEvent:Message,IMessageCallbackEvent
    {
        public const string EventType = "message";

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("event_ts", NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp EventTimestamp { get; set; }
    }
}