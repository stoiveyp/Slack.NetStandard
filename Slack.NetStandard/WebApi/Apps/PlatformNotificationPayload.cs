using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Apps;

public class PlatformNotificationPayload
{
    [JsonProperty("notification_type")]
    public string NotificationType { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }
}