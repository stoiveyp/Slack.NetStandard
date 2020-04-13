using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class SubteamSelfRemoved : CallbackEvent
    {
        public const string EventType = "subteam_self_removed";

        [JsonProperty("subteam_id", NullValueHandling = NullValueHandling.Ignore)]
        public string Subteam { get; set; }
    }
}