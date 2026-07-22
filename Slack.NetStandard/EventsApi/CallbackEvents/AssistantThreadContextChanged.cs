using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class AssistantThreadContextChanged : CallbackEvent
    {
        public const string EventType = "assistant_thread_context_changed";

        [JsonProperty("assistant_thread")]
        public AssistantThread AssistantThread { get; set; }
    }
}
