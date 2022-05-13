using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.EventsApi.CallbackEvents;

public class UserHuddleChanged : CallbackEvent
{
    public const string EventType = "user_huddle_changed";

    [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
    public User User { get; set; }
}