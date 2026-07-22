using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Slack.NetStandard.WebApi.Apps;

public class ExternalAuthStartedPayload
{
    [JsonProperty("team_id",NullValueHandling = NullValueHandling.Ignore)]
    public string TeamId { get; set; }

    [JsonProperty("user_id",NullValueHandling = NullValueHandling.Ignore)]
    public string UserId { get; set; }

    [JsonProperty("app_id",NullValueHandling = NullValueHandling.Ignore)]
    public string AppId { get; set; }

    [JsonProperty("provider_key",NullValueHandling = NullValueHandling.Ignore)]
    public string ProviderKey { get; set; }

    [JsonProperty("code",NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ExternalAuthStartedPayloadCode Code { get; set; }
}