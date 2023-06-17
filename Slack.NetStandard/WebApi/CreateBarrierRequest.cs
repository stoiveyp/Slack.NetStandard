using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi;

public class CreateBarrierRequest
{
    [JsonProperty("barriered_from_usergroup_ids")]
    public List<string> BarrieredFromUserGroupIds { get; set; } = new();

    [JsonProperty("primary_usergroup_id")]
    public string PrimaryUserGroupId { get; set; }

    [JsonProperty("restricted_subjects")] public List<string> RestrictedSubjects { get; set; } = new();

    public bool ShouldSerializeBarrieredFromUserGroupIds() => BarrieredFromUserGroupIds?.Any() ?? false;
    public bool ShouldSerializeRestrictedSubjects() => RestrictedSubjects?.Any() ?? false;
}