using Newtonsoft.Json;
using Slack.NetStandard.Messages;

namespace Slack.NetStandard.Objects.Pins
{
    public class MessagePinnedItem:PinnedItem
    {
        [JsonProperty("message",NullValueHandling = NullValueHandling.Ignore)]
        public Message Message { get; set; }
    }
}
