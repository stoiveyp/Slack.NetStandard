using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class AssistantThreadStarted:CallbackEvent
    {
        public const string EventType = "assistant_thread_started";

        [JsonProperty("assistant_thread")]
        public AssistantThread AssistantThread { get; set; }
    }
}
