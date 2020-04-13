using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.Objects
{
    public class Item
    {
        [JsonProperty("type",NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("channel",NullValueHandling = NullValueHandling.Ignore)]
        public string Channel { get; set; }
        
        [JsonProperty("ts",NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp Timestamp { get; set; }
    }
}
