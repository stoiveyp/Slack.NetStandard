using Newtonsoft.Json;
using Slack.NetStandard.Messages;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.Interaction
{
    public class BlockActionsPayload : InteractionPayload
    {
        [JsonProperty("container", NullValueHandling = NullValueHandling.Ignore)]
        public Container Container { get; set; }

        [JsonProperty("response_url",NullValueHandling = NullValueHandling.Ignore)]
        public string ResponseUrl { get; set; }

        [JsonProperty("view", NullValueHandling = NullValueHandling.Ignore)]
        public View View { get; set; }

        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public Message Message { get; set; }

        [JsonProperty("actions",NullValueHandling = NullValueHandling.Ignore), AcceptedArray]
        public PayloadAction[] Actions { get; set; }

        [JsonProperty("channel", NullValueHandling = NullValueHandling.Ignore)]
        public SlackId Channel { get; set; }

        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public ViewState State { get; set; }
    }
}