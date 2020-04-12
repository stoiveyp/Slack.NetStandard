using Newtonsoft.Json;
using Slack.NetStandard.Objects;
using Slack.NetStandard.WebApi;

namespace Slack.NetStandard.Interaction
{
    public class BlockActionsPayload : InteractionPayload
    {
        [JsonProperty("container", NullValueHandling = NullValueHandling.Ignore)]
        public Container Container { get; set; }


        [JsonProperty("view", NullValueHandling = NullValueHandling.Ignore)]
        public View View { get; set; }

        [JsonProperty("message")]
        public ResponseMessage Message { get; set; }
    }
}