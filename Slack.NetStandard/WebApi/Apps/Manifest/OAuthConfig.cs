using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Apps.Manifest;

public class OAuthConfig
{
    [JsonProperty("redirect_urls",NullValueHandling = NullValueHandling.Ignore)]
    public string[] RedirectUrls { get; set; }

    [JsonProperty("scopes",NullValueHandling = NullValueHandling.Ignore)]
    public Dictionary<string,string[]> Scopes { get; set; }

    [JsonExtensionData]
    public Dictionary<string,object> OtherFields { get; set; }
}