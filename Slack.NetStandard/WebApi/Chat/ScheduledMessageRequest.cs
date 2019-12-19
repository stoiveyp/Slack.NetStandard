using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Chat
{
    public class ScheduledMessageRequest:PostMessageRequest
    {
        [JsonProperty("post_at")]
        public long PostAt { get; set; }
    }
}
