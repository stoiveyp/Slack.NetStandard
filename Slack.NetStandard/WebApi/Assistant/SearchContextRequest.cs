using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Slack.NetStandard.WebApi.Assistant
{
    public class SearchContextRequest
    {
        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("action_token", NullValueHandling = NullValueHandling.Ignore)]
        public string ActionToken { get; set; }

        [JsonProperty("channel_types", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> ChannelTypes { get; set; } = new();

        [JsonProperty("content_types", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> ContentTypes { get; set; } = new();

        [JsonProperty("context_channel_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ContextChannelId { get; set; }

        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; set; }

        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int Limit { get; set; }

        [JsonProperty("include_bots", NullValueHandling = NullValueHandling.Ignore)]
        public bool IncludeBots { get; set; }

        public bool ShouldSerializeContentTypes() => ContentTypes?.Any() ?? false;
        public bool ShouldSerializeChannelTypes() => ChannelTypes?.Any() ?? false;
    }
}
