using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class ChannelHistoryChanged:CallbackEvent
    {
        public const string EventType = "channel_history_changed";

        [JsonProperty("ts",NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp Timestamp { get; set; }

        [JsonProperty("latest",NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp Latest { get; set; }
    }
}
