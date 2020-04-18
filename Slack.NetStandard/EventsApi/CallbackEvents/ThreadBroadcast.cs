using Newtonsoft.Json;
using Slack.NetStandard.Messages;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class ThreadBroadcast : MessageCallbackEvent
    {
        public const string MessageSubType = "thread_broadcast";

        [JsonProperty("root")]
        public Message Message { get; set; }
    }
}