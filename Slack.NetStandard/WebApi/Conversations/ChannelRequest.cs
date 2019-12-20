using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Conversations
{
    internal class ChannelRequest
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }
    }
}
