using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class CallbackEvent:ICallbackEvent
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("event_ts",NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp EventTimestamp { get; set; }

        [JsonExtensionData]
        public Dictionary<string,object> OtherFields { get; set; }
    }
}