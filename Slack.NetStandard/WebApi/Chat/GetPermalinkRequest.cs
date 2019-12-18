using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Chat
{
    class GetPermalinkRequest
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("message_ts")]
        public string Timestamp { get; set; }
    }
}
