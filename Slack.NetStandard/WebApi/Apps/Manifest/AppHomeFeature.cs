using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Apps.Manifest;

public class AppHomeFeature
{
    [JsonProperty("home_tab_enabled",NullValueHandling = NullValueHandling.Ignore)]
    public bool? HomeTabEnabled { get; set; }

    [JsonProperty("messages_tab_enabled",NullValueHandling = NullValueHandling.Ignore)]
    public bool? MessagesTabEnabled { get; set; }

    [JsonProperty("messages_tab_read_only_enabled",NullValueHandling = NullValueHandling.Ignore)]
    public bool? MessagesTabReadOnlyEnabled { get; set; }
}