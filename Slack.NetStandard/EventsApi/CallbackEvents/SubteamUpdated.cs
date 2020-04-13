using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class SubteamUpdated: CallbackEvent
    {
        public const string EventType = "subteam_updated";

        [JsonProperty("subteam")]
        public Usergroup Subteam { get; set; }
    }
}