using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Slack.NetStandard.Objects;
using System.Collections.Generic;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class AppContextChanged : CallbackEvent
    {
        public const string EventType = "app_context_changed";

        [JsonProperty("context")]
        public AppContext Context { get; set; }
    }

    [JsonConverter(typeof(Slack.NetStandard.JsonConverters.ContextEntityConverter))]
    public abstract class ContextEntity
    {
        [JsonProperty("team_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TeamId { get; set; }

        [JsonProperty("enterprise_id", NullValueHandling = NullValueHandling.Ignore)]
        public string EnterpriseId { get; set; }
    }

    public class ChannelIdEntity : ContextEntity
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class CanvasIdEntity : ContextEntity
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class ListIdEntity : ContextEntity
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class MessageContextEntity : ContextEntity
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public MessageValue Value { get; set; }
    }

    public class MessageValue
    {
        [JsonProperty("message_ts")]
        public string MessageTs { get; set; }

        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }
    }

    public class UnknownContextEntity : ContextEntity
    {
        [JsonExtensionData]
        public Dictionary<string, object> OtherFields { get; set; } = new();
    }
}
