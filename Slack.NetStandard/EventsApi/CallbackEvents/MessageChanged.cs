using Newtonsoft.Json;
using Slack.NetStandard.Messages;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class MessageChanged : MessageCallbackEvent
    {
        public const string MessageSubType = "message_changed";

        [JsonProperty("message")]
        public Message Message { get; set; }
    }
}