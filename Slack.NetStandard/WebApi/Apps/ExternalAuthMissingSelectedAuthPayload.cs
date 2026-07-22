using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Apps;

public class ExternalAuthMissingSelectedAuthPayload
{
    [JsonProperty("code")]
    public string Code { get; set; }

    [JsonProperty("team_id")]
    public string TeamId { get; set; }

    [JsonProperty("user_id")]
    public string UserId { get; set; }

    [JsonProperty("provider_key")]
    public string ProviderKey { get; set; }

    [JsonProperty("app_id")]
    public string AppId { get; set; }
}