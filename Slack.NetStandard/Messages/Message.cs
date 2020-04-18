using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Slack.NetStandard.EventsApi.CallbackEvents;
using Slack.NetStandard.JsonConverters;
using Slack.NetStandard.Messages.Blocks;

namespace Slack.NetStandard.Messages
{
    public class Message
    {
        [JsonProperty("channel", NullValueHandling = NullValueHandling.Ignore)]
        public string Channel { get; set; }

        [JsonProperty("blocks", NullValueHandling = NullValueHandling.Ignore)]
        public IList<IMessageBlock> Blocks { get; set; }

        [JsonProperty("channel_type", NullValueHandling = NullValueHandling.Ignore)]
        public string ChannelType { get; set; }

        [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }

        [JsonProperty("thread_ts", NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp ThreadId { get; set; }

        [JsonProperty("edited", NullValueHandling = NullValueHandling.Ignore)]
        public EditDetail Edited { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("ts", NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp Timestamp { get; set; }

        [JsonProperty("subtype", NullValueHandling = NullValueHandling.Ignore)]
        public string Subtype { get; set; }

        [JsonProperty("hidden", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Hidden { get; set; }

        [JsonProperty("is_starred", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsStarred { get; set; }

        [JsonProperty("pinned_to", NullValueHandling = NullValueHandling.Ignore)]
        public string[] PinnedTo { get; set; }

        [JsonProperty("reactions", NullValueHandling = NullValueHandling.Ignore)]
        public Reaction[] Reactions { get; set; }

        [JsonProperty("reply_count", NullValueHandling = NullValueHandling.Ignore)]
        public int? ReplyCount { get; set; }

        [JsonProperty("replies", NullValueHandling = NullValueHandling.Ignore)]
        public Reply[] Replies { get; set; }

        [JsonProperty("username", NullValueHandling = NullValueHandling.Ignore)]
        public string Username { get; set; }

        [JsonProperty("bot_id", NullValueHandling = NullValueHandling.Ignore)]
        public string BotId { get; set; }

        [JsonProperty("icons", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> Icons { get; set; }

        [JsonExtensionData]
        public Dictionary<string,object> OtherFields { get; set; }
    }
}
