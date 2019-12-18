using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Chat
{
    public class MessageResponse:WebApiResponse
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("ts")] 
        public string Timestamp { get; set; }
    }
}
