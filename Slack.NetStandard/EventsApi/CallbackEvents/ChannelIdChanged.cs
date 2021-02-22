using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class ChannelIdChanged : CallbackEvent
    {
        public const string EventType = "channel_id_changed";

        [JsonProperty("old_channel_id")]
        public string OldChannelId { get; set; }

        [JsonProperty("new_channel_id")]
        public string NewChannelId { get; set; }
    }
}