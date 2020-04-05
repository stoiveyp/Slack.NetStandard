using Newtonsoft.Json;

namespace Slack.NetStandard.Interaction
{
    public abstract class InteractiveComponentPayload : InteractionPayload
    {
        [JsonProperty("trigger_id")]
        public string TriggerId { get; set; }

        [JsonProperty("channel")]
        public SlackId Channel { get; set; }

        [JsonProperty("actions", NullValueHandling = NullValueHandling.Ignore)]
        public PayloadAction[] Actions { get; set; }

        [JsonProperty("response_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ResponseUrl { get; set; }
    }
}