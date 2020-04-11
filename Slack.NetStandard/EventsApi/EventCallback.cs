using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi
{
    public class EventCallback:Event
    {
        public const string EventType = "event_callback";

        [JsonProperty("event",NullValueHandling = NullValueHandling.Ignore)]
        public EventType Event { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("team_id")]
        public string TeamId { get; set; }

        [JsonProperty("api_app_id")]
        public string ApiAppId { get; set; }

        [JsonProperty("authed_users",NullValueHandling = NullValueHandling.Ignore)]
        public string[] AuthedUsers { get; set; }

        [JsonProperty("event_id")]
        public string EventId { get; set; }

        [JsonProperty("event_time")]
        public long EventTime { get; set; }
    }
}
