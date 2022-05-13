using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.EventsApi.CallbackEvents;

public class UserProfileChanged : CallbackEvent
{
    public const string EventType = "user_profile_changed";

    [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
    public User User { get; set; }
}