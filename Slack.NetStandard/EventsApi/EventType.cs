using System.Collections.Generic;
using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard.EventsApi
{
    [JsonConverter(typeof(EventTypeConverter))]
    public class EventType
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("event_ts")]
        public Timestamp Timestamp { get; set; }

        [JsonExtensionData]
        public Dictionary<string,object> OtherFields { get; set; }
    }
}