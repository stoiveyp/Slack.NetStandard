using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin;

public class ActiveSession
{
    [JsonProperty("user_id")]
    public string UserId { get; set; }

    [JsonProperty("team_id",NullValueHandling = NullValueHandling.Ignore)]
    public string TeamId { get; set; }

    [JsonProperty("session_id",NullValueHandling = NullValueHandling.Ignore)]
    public long? SessionId { get; set; }

    [JsonProperty("recent",NullValueHandling = NullValueHandling.Ignore)]
    public ActiveSessionDeviceInformation Recent { get; set; }

    [JsonProperty("created",NullValueHandling = NullValueHandling.Ignore)]
    public ActiveSessionDeviceInformation Created { get; set; }
}