using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Slack.NetStandard.WebApi.Admin;

public class LookupRequest
{
    [JsonProperty("last_message_activity_before")]
    public long LastMessageActivityBefore { get; set; }

    [JsonProperty("team_ids")] public List<string> TeamIds { get; set; } = new();

    [JsonProperty("cursor",NullValueHandling = NullValueHandling.Ignore)]
    public string Cursor { get; set; }

    [JsonProperty("limit",NullValueHandling = NullValueHandling.Ignore)]
    public int? Limit { get; set; }

    [JsonProperty("max_member_count",NullValueHandling = NullValueHandling.Ignore)]
    public int? MaxMemberCount { get; set; }

    public bool ShouldSerializeTeamIds() => TeamIds?.Any() ?? false;
}