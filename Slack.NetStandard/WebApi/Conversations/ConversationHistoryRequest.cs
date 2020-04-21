using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Conversations
{
    public class ConversationHistoryRequest
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("cursor",NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; set; }

        [JsonProperty("inclusive",NullValueHandling = NullValueHandling.Ignore)]
        public bool? Inclusive { get; set; }

        [JsonProperty("latest",NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp Latest { get; set; }

        [JsonProperty("oldest",NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp Oldest { get; set; }

        [JsonProperty("limit",NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; set; }
    }
}
