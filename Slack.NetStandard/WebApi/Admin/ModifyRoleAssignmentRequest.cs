using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace Slack.NetStandard.WebApi.Admin;

public class ModifyRoleAssignmentRequest
{
    [JsonProperty("entity_ids")]
    public List<string> EntityIds { get; set; } = new();

    [JsonProperty("role_id")]
    public string RoleId { get; set; }

    [JsonProperty("user_ids", NullValueHandling = NullValueHandling.Ignore)]
    public List<string> UserIds { get; set; } = new();

    public bool ShouldSerializeEntityIds() => EntityIds?.Any() ?? false;
    public bool ShouldSerializeUserIds() => UserIds?.Any() ?? false;
}