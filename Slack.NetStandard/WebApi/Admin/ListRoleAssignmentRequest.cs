using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Linq;

namespace Slack.NetStandard.WebApi.Admin;

public class ListRoleAssignmentRequest
{
    [JsonProperty("cursor",NullValueHandling = NullValueHandling.Ignore)]
    public string Cursor { get; set; }

    [JsonProperty("entity_ids", NullValueHandling = NullValueHandling.Ignore)]
    public List<string> EntityIds { get; set; } = new();

    [JsonProperty("limit",NullValueHandling = NullValueHandling.Ignore)]
    public int? Limit { get; set; }

    [JsonProperty("role_ids", NullValueHandling = NullValueHandling.Ignore)]
    public List<string> RoleIds { get; set; } = new();

    [JsonProperty("sort_dir",NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public SortDirection? SortDirection { get; set; }

    public bool ShouldSerializeEntityIds() => EntityIds?.Any() ?? false;
    public bool ShouldSerializeRoleIds() => RoleIds?.Any() ?? false;
}