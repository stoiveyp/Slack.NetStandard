using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Chat
{
    public class DeleteResponse
    {
        [JsonProperty("ok")]
        public bool OK { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("ts")] 
        public string Timestamp { get; set; }
    }
}
