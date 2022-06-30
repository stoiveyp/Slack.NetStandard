using Newtonsoft.Json;
using Slack.NetStandard.EventsApi.CallbackEvents;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.ApiCommon
{
    public class AppRequest
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("app")]
        public App App { get; set; }

        [JsonProperty("previous_resolution", NullValueHandling = NullValueHandling.Ignore)]
        public Resolution PreviousResolution { get; set; }

        [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
        public UserSummary User { get; set; }

        [JsonProperty("team", NullValueHandling = NullValueHandling.Ignore)]
        public TeamSummary Team { get; set; }

        [JsonProperty("scopes", NullValueHandling = NullValueHandling.Ignore),AcceptedArray]
        public Scope[] Scopes { get; set; }

        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        [JsonProperty("date_created",NullValueHandling = NullValueHandling.Ignore)]
        public long? DateCreated { get; set; }
    }
}