using Newtonsoft.Json;
using Slack.NetStandard.Messages;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class MessageReplied : MessageCallbackEvent
    {
        public const string MessageSubType = "message_replied";

        [JsonProperty("message")]
        public Message Message { get; set; }
    }
}