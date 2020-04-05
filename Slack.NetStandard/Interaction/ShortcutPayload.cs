using Newtonsoft.Json;

namespace Slack.NetStandard.Interaction
{
    public abstract class ShortcutPayload:InteractionPayload
    {
        [JsonProperty("calback_id")]
        public string CallbackId { get; set; }

        [JsonProperty("trigger_id",NullValueHandling = NullValueHandling.Ignore)]
        public string TriggerId { get; set; }
    }
}