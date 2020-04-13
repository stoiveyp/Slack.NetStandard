using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class MemberJoinedChannel : CallbackEvent
    {
        public const string EventType = "member_joined_channel";

        [JsonProperty("user",NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }

        [JsonProperty("channel",NullValueHandling = NullValueHandling.Ignore)]
        public string Channel { get; set; }

        [JsonProperty("channel_type",NullValueHandling = NullValueHandling.Ignore)]
        public string ChannelType { get; set; }

        [JsonProperty("team",NullValueHandling = NullValueHandling.Ignore)]
        public string Team { get; set; }

        [JsonProperty("inviter",NullValueHandling = NullValueHandling.Ignore)]
        public string Inviter { get; set; }
    }
}