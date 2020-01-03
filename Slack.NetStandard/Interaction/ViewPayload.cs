using Newtonsoft.Json;
using Slack.NetStandard.WebApi;

namespace Slack.NetStandard.Interaction
{
    public class ViewPayload : InteractionPayload
    {
        [JsonProperty("view", NullValueHandling = NullValueHandling.Ignore)]
        public View View { get; set; }

        [JsonProperty("container", NullValueHandling = NullValueHandling.Ignore)]
        public ViewContainer Container { get; set; }
    }
}