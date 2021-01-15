using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.Socket
{
    public class Hello
    {
        public const string EventType = "hello";

        [JsonProperty("type")] public string Type => EventType;

        [JsonProperty("num_connections")]
        public int NumberOfConnections { get; set; }

        [JsonProperty("connection_info")]
        public HelloConnectionInformation ConnectionInfo { get; set; }

        [JsonProperty("debug_info", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> DebugInfo { get; set; }
    }
}
