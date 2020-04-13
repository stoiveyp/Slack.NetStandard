using System.Collections.Generic;
using System.Net.NetworkInformation;
using Newtonsoft.Json;
using Slack.NetStandard.Messages.Blocks;

namespace Slack.NetStandard.Messages
{
    public class Message
    {
        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("blocks", NullValueHandling = NullValueHandling.Ignore)]
        public IList<IMessageBlock> Blocks { get; set; }

        [JsonProperty("thread_ts", NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp ThreadId { get; set; }

        [JsonProperty("ts", NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp MessageId { get; set; }

        [JsonProperty("mrkdwn", NullValueHandling = NullValueHandling.Ignore)]
        public bool? UseMarkdown { get; set; }

        [JsonProperty("edited", NullValueHandling = NullValueHandling.Ignore)]
        public EditDetail Edited { get; set; }

        [JsonProperty("reply_count",NullValueHandling = NullValueHandling.Ignore)]
        public int? ReplyCount { get; set; }

        [JsonProperty("replies",NullValueHandling = NullValueHandling.Ignore)]
        public Reply[] Replies { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> OtherFields { get; set; }
    }
}
