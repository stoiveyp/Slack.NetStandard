using Newtonsoft.Json;

namespace Slack.NetStandard.Objects
{
    public class Share
    {
        [JsonProperty("reply_users",NullValueHandling = NullValueHandling.Ignore),AcceptedArray]
        public string[] ReplyUsers { get; set; }

        [JsonProperty("reply_count",NullValueHandling = NullValueHandling.Ignore)]
        public int? ReplyCount { get; set; }

        [JsonProperty("reply_users_count",NullValueHandling = NullValueHandling.Ignore)]
        public int? ReplyUsersCount { get; set; }

        [JsonProperty("latest_reply",NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp LatestReply { get; set; }

        [JsonProperty("thread_ts",NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp ThreadTimestamp { get; set; }

        [JsonProperty("channel_name",NullValueHandling = NullValueHandling.Ignore)]
        public string ChannelName { get; set; }

        [JsonProperty("team_id",NullValueHandling = NullValueHandling.Ignore)]
        public string TeamId { get; set; }

        [JsonProperty("ts",NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp Timestamp { get; set; }

    }
}