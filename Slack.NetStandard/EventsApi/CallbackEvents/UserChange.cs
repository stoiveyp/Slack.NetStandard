using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class UserChange : CallbackEvent
    {
        public const string EventType = "user_change";

        [JsonProperty("user",NullValueHandling = NullValueHandling.Ignore)]
        public User User { get; set; }
    }
}