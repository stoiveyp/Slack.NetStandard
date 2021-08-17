using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class LinkShared : CallbackEvent
    {
        public const string EventType = "link_shared";

        [JsonProperty("channel",NullValueHandling = NullValueHandling.Ignore)]
        public string Channel { get; set; }

        [JsonProperty("user",NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }

        [JsonProperty("is_bot_user_member", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsBotUserMember { get; set; }

        [JsonProperty("unfurl_id",NullValueHandling = NullValueHandling.Ignore)]
        public string UnfurlId { get; set; }

        [JsonProperty("source",NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get; set; }

        [JsonProperty("message_ts",NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp MessageTimestamp { get; set; }

        [JsonProperty("thread_ts",NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp ThreadTimestamp { get; set; }

        [JsonProperty("links",NullValueHandling = NullValueHandling.Ignore)]
        public Link[] Links { get; set; }
    }
}