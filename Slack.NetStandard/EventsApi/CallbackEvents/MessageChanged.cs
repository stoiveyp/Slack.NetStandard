using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class MessageChanged : Message
    {
        public const string MessageSubType = "message_changed";

        [JsonProperty("message")]
        public Messages.Message Message { get; set; }
    }
}