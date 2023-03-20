using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class PinRemoved : CallbackEventWithItem
    {
        public const string EventType = "pin_removed";

        [JsonProperty("channel_id", NullValueHandling = NullValueHandling.Ignore)]
        public string Channel { get; set; }


        [JsonProperty("has_pins",NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasPins { get; set; }
    }
}