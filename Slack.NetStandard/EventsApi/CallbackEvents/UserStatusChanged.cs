using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.EventsApi.CallbackEvents;

public class UserStatusChanged : CallbackEvent
{
    public const string EventType = "user_status_changed";

    [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
    public User User { get; set; }
}