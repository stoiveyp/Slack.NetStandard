using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace Slack.NetStandard.WebApi.Apps.Manifest;

public class OAuthConfig
{
    [JsonProperty("redirect_urls",NullValueHandling = NullValueHandling.Ignore)]
    public IList<string> RedirectUrls { get; set; } = new List<string>();

    [JsonProperty("scopes",NullValueHandling = NullValueHandling.Ignore)]
    public Dictionary<string,string[]> Scopes { get; set; }

    [JsonExtensionData]
    public Dictionary<string,object> OtherFields { get; set; }

    public bool ShouldSerializeRedirectUrls() => RedirectUrls?.Any() ?? false;
}