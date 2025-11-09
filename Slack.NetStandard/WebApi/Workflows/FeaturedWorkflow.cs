using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Workflows
{
    public class FeaturedWorkflow
    {
        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        [JsonProperty("triggers")]
        [AcceptedArray]
        public Trigger[] Triggers { get; set; }
    }
}