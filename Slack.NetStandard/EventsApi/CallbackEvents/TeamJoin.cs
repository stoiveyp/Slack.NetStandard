using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class TeamJoin : CallbackEvent
    {
        public const string EventType = "team_join";

        [JsonProperty("user",NullValueHandling = NullValueHandling.Ignore)]
        public User User { get; set; }
    }
}