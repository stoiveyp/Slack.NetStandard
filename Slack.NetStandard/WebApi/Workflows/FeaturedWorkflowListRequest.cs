using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Slack.NetStandard.WebApi.Workflows
{
    
    internal class FeaturedWorkflowListRequest
    {
        public FeaturedWorkflowListRequest(IEnumerable<string> channelIds) {
            ChannelIds = channelIds.ToList();
        }

        [JsonProperty("channel_ids")]
        public List<string> ChannelIds { get; } = new();

        public bool ShouldSerializeChannelIds() => true;
    }
}
