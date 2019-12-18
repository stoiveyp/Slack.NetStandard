using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Slack.NetStandard.Messages.Blocks;

namespace Slack.NetStandard.WebApi.Chat
{
    public class UnfurlRequest
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("ts")]
        public string Timestamp { get; set; }

        [JsonProperty("unfurls")]
        public Dictionary<string,IMessageBlock[]> Unfurls { get; set; }

        [JsonProperty("user_auth_message",NullValueHandling = NullValueHandling.Ignore)]
        public string UserAuthMessage { get; set; }

        [JsonProperty("user_auth_required",NullValueHandling = NullValueHandling.Ignore)]
        public bool? UserAuthRequired { get; set; }

        [JsonProperty("user_auth_url",NullValueHandling = NullValueHandling.Ignore)]
        public string UserAuthUrl { get; set; }
    }
}
