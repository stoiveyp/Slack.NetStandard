using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class ChannelCreated : CallbackEvent
    {
        public const string EventType = "channel_created";

        [JsonProperty("channel",NullValueHandling = NullValueHandling.Ignore)]
        public ChannelCreationDetail Channel { get; set; }
    }
}