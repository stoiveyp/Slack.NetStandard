using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

public class CustomRetentionResponse : WebApiResponse
{
    [JsonProperty("is_policy_enabled")]
    public bool IsPolicyEnabled { get; set; }

    [JsonProperty("duration_days")]
    public int DurationDays { get; set; }
}