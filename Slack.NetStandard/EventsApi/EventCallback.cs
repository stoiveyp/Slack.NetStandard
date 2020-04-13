using Newtonsoft.Json;
using Slack.NetStandard.EventsApi.CallbackEvents;

namespace Slack.NetStandard.EventsApi
{
    public class EventCallbackBase : Event
    {
        public const string EventType = "event_callback";

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("team_id")]
        public string TeamId { get; set; }

        [JsonProperty("api_app_id")]
        public string ApiAppId { get; set; }

        [JsonProperty("authed_users", NullValueHandling = NullValueHandling.Ignore)]
        public string[] AuthedUsers { get; set; }

        [JsonProperty("event_id")]
        public string EventId { get; set; }

        [JsonProperty("event_time")]
        public long EventTime { get; set; }
    }

    public class EventCallback: EventCallbackBase
    {
        [JsonProperty("event",NullValueHandling = NullValueHandling.Ignore)]
        public CallbackEvent Event { get; set; }
    }

    public class EventCallback<T> : EventCallbackBase where T:CallbackEvent
    {
        [JsonProperty("event", NullValueHandling = NullValueHandling.Ignore)]
        public T Event { get; set; }
    }
}
