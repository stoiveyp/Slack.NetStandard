using Newtonsoft.Json;

namespace Slack.NetStandard.Interaction
{
    public abstract class ShortcutPayload:InteractionPayload
    {
        [JsonProperty("callback_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CallbackId { get; set; }

        [JsonProperty("trigger_id",NullValueHandling = NullValueHandling.Ignore)]
        public string TriggerId { get; set; }
    }
}