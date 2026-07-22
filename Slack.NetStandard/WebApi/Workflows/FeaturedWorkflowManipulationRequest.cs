using Newtonsoft.Json;
using System.Collections.Generic;

namespace Slack.NetStandard.WebApi.Workflows
{
    internal class FeaturedWorkflowManipulationRequest
    {
        public FeaturedWorkflowManipulationRequest(string channelId, List<string> triggerIds)
        {
            ChannelId = channelId;
            TriggerIds = triggerIds;
        }

        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        [JsonProperty("trigger_ids")]
        public List<string> TriggerIds { get; set; } = new();

        public bool ShouldSerializeTriggerIds() => true;
    }
}
