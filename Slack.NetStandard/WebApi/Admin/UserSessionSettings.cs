using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

public class UserSessionSettings
{
    [JsonProperty("user_id")]
    public string UserId { get; set; }

    [JsonProperty("desktop_app_browser_quit",NullValueHandling = NullValueHandling.Ignore)]
    public bool DesktopAppBrowserQuit { get; set; }

    [JsonProperty("duration",NullValueHandling = NullValueHandling.Ignore)]
    public long Duration { get; set; }
}