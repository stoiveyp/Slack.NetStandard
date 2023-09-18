using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

public class AppConfigLookupResponse:WebApiResponse
{
    [JsonProperty("configs",NullValueHandling = NullValueHandling.Ignore)]
    public AppConfig[] Configs { get; set; }
}