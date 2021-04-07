using Newtonsoft.Json;
using Slack.NetStandard.Messages;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.Interaction
{
    public class SuggestionPayload : InteractionPayload
    {
        [JsonProperty("container", NullValueHandling = NullValueHandling.Ignore)]
        public Container Container { get; set; }

        [JsonProperty("view", NullValueHandling = NullValueHandling.Ignore)]
        public View View { get; set; }

        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public Message Message { get; set; }

        [JsonProperty("channel", NullValueHandling = NullValueHandling.Ignore)]
        public SlackId Channel { get; set; }

        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public ViewState State { get; set; }

        [JsonProperty("action_id",NullValueHandling = NullValueHandling.Ignore)]
        public string ActionId { get; set; }

        [JsonProperty("block_id", NullValueHandling = NullValueHandling.Ignore)]
        public string BlockId { get; set; }

        [JsonProperty("value",NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }
    }
}