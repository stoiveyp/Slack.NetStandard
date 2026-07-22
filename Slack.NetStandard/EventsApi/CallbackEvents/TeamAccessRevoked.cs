using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents;

public class TeamAccessRevoked : CallbackEvent
{
    public const string EventType = "team_access_revoked";
    
    [JsonProperty("team_ids", NullValueHandling = NullValueHandling.Ignore)]
    public string[] TeamIds { get; set; }
}