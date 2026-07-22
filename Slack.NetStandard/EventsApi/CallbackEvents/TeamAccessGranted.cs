using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents;

public class TeamAccessGranted : CallbackEvent
{
    public const string EventType = "team_access_granted";
    
    [JsonProperty("team_ids", NullValueHandling = NullValueHandling.Ignore)]
    public string[] TeamIds { get; set; }
}