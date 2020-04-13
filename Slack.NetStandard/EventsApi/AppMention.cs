using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi
{
    public class AppMention:EventType
    {
        public const string EventType = "app_mention";

        [JsonProperty("user",NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }

        [JsonProperty("text",NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("ts",NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp Timestamp { get; set; }

        [JsonProperty("channel",NullValueHandling = NullValueHandling.Ignore)]
        public string Channel { get; set; }
    }
}
