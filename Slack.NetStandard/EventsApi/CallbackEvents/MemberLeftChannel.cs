using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class MemberLeftChannel : CallbackEvent
    {
        public const string EventType = "member_left_channel";

        [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }

        [JsonProperty("channel", NullValueHandling = NullValueHandling.Ignore)]
        public string Channel { get; set; }

        [JsonProperty("channel_type", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ChannelType ChannelType { get; set; }

        [JsonProperty("team", NullValueHandling = NullValueHandling.Ignore)]
        public string Team { get; set; }
    }
}