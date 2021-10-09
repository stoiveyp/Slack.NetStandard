using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Apps.Manifest;

public class BotUserFeature
{
    [JsonProperty("display_name",NullValueHandling = NullValueHandling.Ignore)]
    public string DisplayName { get; set; }

    [JsonProperty("always_online",NullValueHandling = NullValueHandling.Ignore)]
    public bool? AlwaysOnline { get; set; }

    [JsonExtensionData]
    public Dictionary<string,object> OtherFields { get; set; }
}