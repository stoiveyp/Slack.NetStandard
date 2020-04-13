using System.Collections.Generic;
using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    [JsonConverter(typeof(CallbackEventConverter))]
    public class CallbackEvent
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("event_ts",NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp EventTimestamp { get; set; }

        [JsonExtensionData]
        public Dictionary<string,object> OtherFields { get; set; }
    }
}