using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

public class PermissionLookupType
{
    [JsonProperty("permission_type")]
    public string PermissionType { get; set; }
}