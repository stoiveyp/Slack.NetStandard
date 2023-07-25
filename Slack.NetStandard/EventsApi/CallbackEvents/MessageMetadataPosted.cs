using System.Collections.Generic;
using Newtonsoft.Json;
using Slack.NetStandard.Messages;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class MessageMetadataPosted: CallbackEvent
    {
        public const string EventType = "message_metadata_posted";

        [JsonProperty("app_id", NullValueHandling = NullValueHandling.Ignore)]
        public string AppId { get; set; }

        [JsonProperty("bot_id", NullValueHandling = NullValueHandling.Ignore)]
        public string BotId { get; set; }

        [JsonProperty("user_id",NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }

        [JsonProperty("channel_id",NullValueHandling = NullValueHandling.Ignore)]
        public string ChannelId { get; set; }

        [JsonProperty("team_id",NullValueHandling = NullValueHandling.Ignore)]
        public string TeamId { get; set; }

        [JsonProperty("message_ts",NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp MessageTimestamp { get; set; }

        [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
        public MessageMetadata Metadata { get; set; }
    }
}
