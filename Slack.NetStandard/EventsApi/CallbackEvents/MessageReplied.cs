using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class MessageReplied : Message
    {
        public const string MessageSubType = "message_replied";

        [JsonProperty("message")]
        public Messages.Message Message { get; set; }
    }
}