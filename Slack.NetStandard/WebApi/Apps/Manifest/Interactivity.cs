using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Apps.Manifest;

public class Interactivity
{
    [JsonProperty("is_enabled")]
    public bool IsEnabled { get; set; }

    [JsonProperty("request_url",NullValueHandling = NullValueHandling.Ignore)]
    public string RequestUrl { get; set; }

    [JsonProperty("message_menu_options_url", NullValueHandling = NullValueHandling.Ignore)]
    public string MessageMenuOptionsUrl { get; set; }
}