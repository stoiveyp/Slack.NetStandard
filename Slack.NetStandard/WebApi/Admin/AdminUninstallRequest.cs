using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

internal class AdminUninstallRequest
{
    [JsonProperty("app_id", NullValueHandling = NullValueHandling.Ignore)]
    public string AppId { get; set; }

    [JsonProperty("request_id", NullValueHandling = NullValueHandling.Ignore)]
    public string RequestId { get; set; }

    [JsonProperty("team_ids", NullValueHandling = NullValueHandling.Ignore)]
    public List<string> TeamIds { get; set; } = new();

    [JsonProperty("enterprise_id", NullValueHandling = NullValueHandling.Ignore)]
    public string EnterpriseId { get; set; }

    public bool ShouldSerializeTeamIds() => TeamIds?.Any() ?? false;
}