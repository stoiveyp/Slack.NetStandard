using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class SubteamSelfAdded : CallbackEvent
    {
        public const string EventType = "subteam_self_added";

        [JsonProperty("subteam_id",NullValueHandling = NullValueHandling.Ignore)]
        public string Subteam { get; set; }
    }
}