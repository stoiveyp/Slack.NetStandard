using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class PinAdded : CallbackEventWithItem
    {
        public const string EventType = "pin_added";

        [JsonProperty("channel_id",NullValueHandling = NullValueHandling.Ignore)]
        public string Channel { get; set; }
    }
}
