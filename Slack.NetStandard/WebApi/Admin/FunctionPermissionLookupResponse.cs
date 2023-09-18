using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

public class FunctionPermissionLookupResponse:WebApiResponse
{
    [JsonProperty("permissions", NullValueHandling = NullValueHandling.Ignore)]
    public Dictionary<string, FunctionPermissionLookup> Permissions { get; set; } = new();

    public bool ShouldSerializePermissions() => Permissions?.Any() ?? false;
}