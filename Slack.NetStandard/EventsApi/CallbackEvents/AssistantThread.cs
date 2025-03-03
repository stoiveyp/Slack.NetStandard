using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class AssistantThread
    {
        [JsonProperty("user_id", NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }

        [JsonProperty("channel_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ChannelId { get; set; }

        [JsonProperty("thread_ts", NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp ThreadTimestamp { get; set; }

        [JsonProperty("context")]
        public AssistantThreadContext Context { get; set; }
    }
}