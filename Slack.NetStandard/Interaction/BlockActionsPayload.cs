using Newtonsoft.Json;

namespace Slack.NetStandard.Interaction
{
    public class BlockActionsPayload : InteractionPayload
    {
        [JsonProperty("container", NullValueHandling = NullValueHandling.Ignore)]
        public ViewContainer Container { get; set; }


        [JsonProperty("view", NullValueHandling = NullValueHandling.Ignore)]
        public View View { get; set; }
    }
}