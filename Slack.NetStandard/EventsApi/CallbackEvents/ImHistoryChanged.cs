using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class ImHistoryChanged : CallbackEvent
    {
        public const string EventType = "im_history_changed";

        [JsonProperty("ts", NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp Timestamp { get; set; }

        [JsonProperty("latest", NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp Latest { get; set; }
    }
}