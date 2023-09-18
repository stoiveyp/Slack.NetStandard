using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

[AcceptedArray]
public class PermissionLookupType
{
    [JsonProperty("permission_type")]
    public string PermissionType { get; set; }

    [JsonProperty("user_ids",NullValueHandling = NullValueHandling.Ignore)]
    public string[] UserIds { get; set; }

    [JsonProperty("channel_ids",NullValueHandling = NullValueHandling.Ignore)]
    public string[] ChannelIds { get; set; }

    [JsonProperty("team_ids",NullValueHandling = NullValueHandling.Ignore)]
    public string[] TeamIds { get; set; }

    [JsonProperty("org_ids", NullValueHandling = NullValueHandling.Ignore)]
    public string[] OrgIds { get; set; }
}