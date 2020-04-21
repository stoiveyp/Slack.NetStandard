using Newtonsoft.Json;
using Slack.NetStandard.EventsApi.CallbackEvents;
using Slack.NetStandard.Messages;
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

        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public Message Message { get; set; }
    }
}