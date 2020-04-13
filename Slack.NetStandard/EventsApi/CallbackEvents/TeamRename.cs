using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class TeamRename : CallbackEvent
    {
        public const string EventType = "team_rename";

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name{ get; set; }
    }
}