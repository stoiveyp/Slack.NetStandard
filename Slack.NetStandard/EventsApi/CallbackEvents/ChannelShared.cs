using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class ChannelShared:CallbackEvent
    {
        public const string EventType = "channel_shared";

        [JsonProperty("channel",NullValueHandling = NullValueHandling.Ignore)]
        public string Channel { get; set; }

        [JsonProperty("connected_team_id",NullValueHandling = NullValueHandling.Ignore)]
        public string ConnectedTeamId { get; set; }

    }
}