using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    [Obsolete("This event is being deprecated in February 2027. Please refer to https://docs.slack.dev/ai/migrating-to-agent-messaging/ for more information on migrating to agent messaging", false)]
    public class AssistantThreadStarted:CallbackEvent
    {
        public const string EventType = "assistant_thread_started";

        [JsonProperty("assistant_thread")]
        public AssistantThread AssistantThread { get; set; }
    }
}
