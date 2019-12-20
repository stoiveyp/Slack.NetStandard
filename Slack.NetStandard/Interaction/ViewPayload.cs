using Newtonsoft.Json;
using Slack.NetStandard.WebApi;

namespace Slack.NetStandard.Interaction
{
    public class ViewPayload : InteractionPayload
    {
        [JsonProperty("view")]
        public View View { get; set; }

        [JsonProperty("container")]
        public ViewContainer Container { get; set; }
    }
}