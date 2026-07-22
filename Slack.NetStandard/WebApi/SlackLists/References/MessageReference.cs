using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.SlackLists.References
{
    public class MessageReference:SlackListsReference
    {
        public MessageReference() { }

        public MessageReference(string channelId, Timestamp timestamp, Timestamp threadTs = null)
        {
            ChannelId = channelId;
            Timestamp = timestamp;
            ThreadTimestamp = threadTs;
        }

        [JsonProperty("channel_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ChannelId { get; set; }

        [JsonProperty("ts", NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp Timestamp { get; set; }

        [JsonProperty("thread_ts", NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp ThreadTimestamp { get; set; }
    }
}
