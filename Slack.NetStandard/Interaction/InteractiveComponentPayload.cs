using Newtonsoft.Json;

namespace Slack.NetStandard.Interaction
{
    public abstract class InteractiveComponentPayload : InteractionPayload
    {
        [JsonProperty("actions", NullValueHandling = NullValueHandling.Ignore)]
        public PayloadAction[] Actions { get; set; }

        [JsonProperty("response_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ResponseUrl { get; set; }

        [JsonProperty("channel", NullValueHandling = NullValueHandling.Ignore)]
        public SlackId Channel { get; set; }
    }
}