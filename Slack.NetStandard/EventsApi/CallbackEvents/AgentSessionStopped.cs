using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class AgentSessionStopped : CallbackEvent
    {
        public const string EventType = "agent_session_stopped";

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("streaming_message_ts", NullValueHandling = NullValueHandling.Ignore)]
        public List<Timestamp> StreamingMessageTs { get; set; } = new();

        [JsonProperty("thread_ts", NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp ThreadTimestamp { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        public bool ShouldSerializeStreamingMessageTs() => true;
    }
}
