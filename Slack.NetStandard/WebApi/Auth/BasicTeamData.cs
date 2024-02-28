using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Auth;

public class BasicTeamData : SlackId
{
    [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
    public Dictionary<string, string> Icon { get; set; }
}