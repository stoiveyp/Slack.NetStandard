using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

public class FunctionPermissionAllowance
{
    [JsonProperty("type")]
    public string Type { get; set; }

    [AcceptedArray]
    [JsonProperty("user_ids",NullValueHandling = NullValueHandling.Ignore)]
    public string[] UserIds { get; set; }
}