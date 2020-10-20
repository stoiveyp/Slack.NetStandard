using System;
using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;
using Slack.NetStandard.Objects;

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

        [JsonProperty("authorizations", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(AuthorizationConverter))]
        public Authorization[] Authorizations { get; set; }

        [JsonProperty("authed_users", NullValueHandling = NullValueHandling.Ignore)]
        [Obsolete("authed users will be removed in a future release. Please use a token with authorizations:read permission and the WebApi.Apps.ListAuthorizations method")]
        public string[] AuthedUsers { get; set; }

        [JsonProperty("event_context")]
        public string EventContext { get; set; }

        [JsonProperty("event_id")]
        public string EventId { get; set; }

        [JsonProperty("event_time")]
        public long EventTime { get; set; }
    }
}