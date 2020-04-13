using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class PinAdded:CallbackEvent
    {
        public const string EventType = "pin_added";

        [JsonProperty("user",NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }

        [JsonProperty("channel_id",NullValueHandling = NullValueHandling.Ignore)]
        public string Channel { get; set; }

        [JsonProperty("event_ts",NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp EventTimestamp { get; set; }

        [JsonProperty("item",NullValueHandling = NullValueHandling.Ignore)]
        public Item Item { get; set; }
    }
}
