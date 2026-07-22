using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Apps;

public class ExternalTokenResponse : WebApiResponse
{
    [JsonProperty("external_token", NullValueHandling = NullValueHandling.Ignore)]
    public string ExternalToken { get; set; }
}