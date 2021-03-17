using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.Interaction
{
    public class InteractiveMessagePayload : InteractionPayload
    {
        [JsonProperty("name",NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("value",NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }

        [JsonProperty("callback_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CallbackId { get; set; }

        [JsonProperty("message_ts", NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp MessageTimestamp { get; set; }

        [JsonProperty("channel",NullValueHandling = NullValueHandling.Ignore)]
        public Channel Channel { get; set; }

        [JsonProperty("attachment_id",NullValueHandling = NullValueHandling.Ignore)]
        public string AttachmentId { get; set; }
    }
}