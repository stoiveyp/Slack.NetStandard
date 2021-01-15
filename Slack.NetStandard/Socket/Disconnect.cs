using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.Socket
{
    public class Disconnect
    {
        public const string EventType = "disconnect";

        [JsonProperty("type")] public string Type => EventType;

        [JsonProperty("reason")] public string Reason { get; set; }

        [JsonProperty("debug_info", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> DebugInfo { get; set; }
    }
}
