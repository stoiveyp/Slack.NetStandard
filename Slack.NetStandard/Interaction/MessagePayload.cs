using Newtonsoft.Json;
using Slack.NetStandard.WebApi;

namespace Slack.NetStandard.Interaction
{
    public class MessagePayload : InteractionPayload
    {
        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public ResponseMessage Message { get; set; }

        [JsonProperty("container", NullValueHandling = NullValueHandling.Ignore)]
        public MessageContainer Container { get; set; }

    }
}