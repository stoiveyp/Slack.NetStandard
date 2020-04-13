using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class Message : CallbackEvent
    {
        public const string EventType = "message";

        [JsonProperty("channel",NullValueHandling = NullValueHandling.Ignore)]
        public string Channel { get; set; }

        [JsonProperty("channel_type",NullValueHandling = NullValueHandling.Ignore)]
        public string ChannelType { get; set; }

        [JsonProperty("user",NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }

        [JsonProperty("text",NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("ts",NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp Timestamp { get; set; }

        [JsonProperty("subtype", NullValueHandling = NullValueHandling.Ignore)]
        public string Subtype { get; set; }

        [JsonProperty("hidden",NullValueHandling = NullValueHandling.Ignore)]
        public bool? Hidden { get; set; }

        [JsonProperty("is_starred",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsStarred { get; set; }

        [JsonProperty("pinned_to",NullValueHandling = NullValueHandling.Ignore)]
        public string[] PinnedTo { get; set; }

        [JsonProperty("reactions",NullValueHandling = NullValueHandling.Ignore)]
        public Reaction[] Reactions { get; set; }
    }
}