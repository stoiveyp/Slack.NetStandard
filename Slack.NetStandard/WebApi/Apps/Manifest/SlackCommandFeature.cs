using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Apps.Manifest;

public class SlackCommandFeature
{
    [JsonProperty("command",NullValueHandling = NullValueHandling.Ignore)]
    public string Command { get; set; }

    [JsonProperty("description",NullValueHandling = NullValueHandling.Ignore)]
    public string Description { get; set; }

    [JsonProperty("usage_hint",NullValueHandling = NullValueHandling.Ignore)]
    public string UsageHint { get; set; }

    [JsonProperty("should_escape",NullValueHandling = NullValueHandling.Ignore)]
    public bool? ShouldEscape { get; set; }
}