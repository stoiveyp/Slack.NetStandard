using System.Reflection;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

public class FunctionPermissionLookup
{
    [JsonProperty("distribution",NullValueHandling = NullValueHandling.Ignore)]
    public FunctionPermissionAllowance Distribution { get; set; }

    [JsonProperty("allowed_by_admin", NullValueHandling = NullValueHandling.Ignore)]
    public FunctionPermissionAllowance AllowedByAdmin { get; set; }

    [JsonProperty("allowed_entities",NullValueHandling = NullValueHandling.Ignore)]
    public FunctionPermissionAllowance AllowedEntities { get; set; }
}