using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Slack.NetStandard.WebApi.Apps;

public class FunctionDeploymentPayload
{
    [JsonProperty("action",NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public FunctionDeploymentAction Action { get; set; }

    [JsonProperty("team_id",NullValueHandling = NullValueHandling.Ignore)]
    public string TeamId { get; set; }

    [JsonProperty("user_id",NullValueHandling = NullValueHandling.Ignore)]
    public string UserId { get; set; }

    [JsonProperty("bundle_size_kb",NullValueHandling = NullValueHandling.Ignore)]
    public long? BundleSizeKb { get; set; }
}