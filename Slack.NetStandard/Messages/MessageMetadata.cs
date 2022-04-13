using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.Messages
{
    public class MessageMetadata
    {
        [JsonProperty("event_type")]
        public string EventType { get; set; }

        [JsonProperty("event_payload",NullValueHandling = NullValueHandling.Ignore)]
        public object EventPayload { get; set; }
    }
}
