using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

public class ListSessionRequest
{
    [JsonProperty("cursor",NullValueHandling = NullValueHandling.Ignore)]
    public string Cursor { get; set; }

    [JsonProperty("limit",NullValueHandling = NullValueHandling.Ignore)]
    public int? Limit { get; set; }

    [JsonProperty("team_id",NullValueHandling = NullValueHandling.Ignore)]
    public string TeamId { get; set; }

    [JsonProperty("user_id",NullValueHandling = NullValueHandling.Ignore)]
    public string UserId { get; set; }
}