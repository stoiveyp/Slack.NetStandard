using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class TeamDomainChange : CallbackEvent
    {
        public const string EventType = "team_domain_change";

        [JsonProperty("url",NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        [JsonProperty("domain",NullValueHandling = NullValueHandling.Ignore)]
        public string Domain { get; set; }
    }
}