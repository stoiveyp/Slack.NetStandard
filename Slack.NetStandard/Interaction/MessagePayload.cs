using Newtonsoft.Json;
using Slack.NetStandard.WebApi;

namespace Slack.NetStandard.Interaction
{
    public class BlockActionsPayload : InteractionPayload
    {
        [JsonProperty("message")]
        public ResponseMessage Message { get; set; }

        [JsonProperty("container")]
        public MessageContainer Container { get; set; }

        [JsonProperty("trigger_id")]
        public string TriggerId { get; set; }

        [JsonProperty("channel")]
        public PayloadChannel Channel { get; set; }

        [JsonProperty("actions", NullValueHandling = NullValueHandling.Ignore)]
        public PayloadAction[] Actions { get; set; }

        [JsonProperty("response_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ResponseUrl { get; set; }

    }
}