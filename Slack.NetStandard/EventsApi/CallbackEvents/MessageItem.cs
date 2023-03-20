using Newtonsoft.Json;
using Slack.NetStandard.Messages;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class MessageItem : Item
    {
        public const string ItemSubType = "message";

        [JsonProperty("message")]
        public Message Message { get; set; }
    }
}