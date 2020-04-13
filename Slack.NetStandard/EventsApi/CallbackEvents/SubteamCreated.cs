using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class SubteamCreated : CallbackEvent
    {
        public const string EventType = "subteam_created";

        [JsonProperty("subteam")]
        public Usergroup Subteam { get; set; }
    }
}