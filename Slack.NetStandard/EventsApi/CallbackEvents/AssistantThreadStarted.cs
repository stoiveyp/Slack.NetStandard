using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class AssistantThreadStarted:CallbackEvent
    {
        public const string EventType = "assistant_thread_started";

        [JsonProperty("assistant_thread")]
        public AssistantThread AssistantThread { get; set; }
    }
}
