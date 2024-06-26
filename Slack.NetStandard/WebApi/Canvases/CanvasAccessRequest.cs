using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Slack.NetStandard.WebApi.Canvases
{
    public class CanvasAccessRequest
    {
        [JsonProperty("canvas_id")]
        public string CanvasId { get; set; }

        [JsonProperty("channel_ids")]
        public List<string> ChannelIds { get; set; } = new();

        [JsonProperty("user_ids")]
        public List<string> UserIds { get; set; } = new();

        public bool ShouldSerializeChannelIds() => ChannelIds?.Any() ?? false;
        public bool ShouldSerializeUserIds() => UserIds?.Any() ?? false;
    }
}