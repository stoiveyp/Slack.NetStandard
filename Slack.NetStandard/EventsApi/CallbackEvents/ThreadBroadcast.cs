using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class ThreadBroadcast : Message
    {
        public const string MessageSubType = "thread_broadcast";

        [JsonProperty("root")]
        public Messages.Message Message { get; set; }
    }
}