using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Slack.NetStandard.ApiCommon;
using Slack.NetStandard.Messages.Blocks;
using Slack.NetStandard.Objects;
using Slack.NetStandard.WebApi.Bots;
using File = Slack.NetStandard.Objects.File;

namespace Slack.NetStandard.Messages
{
    public class Message
    {
        [JsonProperty("channel", NullValueHandling = NullValueHandling.Ignore)]
        public Channel Channel { get; set; }

        [JsonProperty("blocks", NullValueHandling = NullValueHandling.Ignore)]
        public IList<IMessageBlock> Blocks { get; set; } = new List<IMessageBlock>();

        [JsonProperty("attachments", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Attachment> Attachments{ get; set; } = new List<Attachment>();

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

        [JsonProperty("pinned_to", NullValueHandling = NullValueHandling.Ignore), AcceptedArray]
        public string[] PinnedTo { get; set; }

        [JsonProperty("reactions", NullValueHandling = NullValueHandling.Ignore), AcceptedArray]
        public Reaction[] Reactions { get; set; }

        [JsonProperty("reply_count", NullValueHandling = NullValueHandling.Ignore)]
        public int? ReplyCount { get; set; }

        [JsonProperty("reply_users",NullValueHandling = NullValueHandling.Ignore), AcceptedArray]
        public string[] ReplyUsers { get; set; }

        [JsonProperty("reply_users_count",NullValueHandling = NullValueHandling.Ignore)]
        public int? ReplyUsersCount { get; set; }

        [JsonProperty("latest_reply",NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp LatestReply { get; set; }

        [JsonProperty("username", NullValueHandling = NullValueHandling.Ignore)]
        public string Username { get; set; }

        [JsonProperty("bot_id", NullValueHandling = NullValueHandling.Ignore)]
        public string BotId { get; set; }

        [JsonProperty("bot_profile", NullValueHandling = NullValueHandling.Ignore)]
        public BotInfo BotInfo { get; set; }

        [JsonProperty("icons", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> Icons { get; set; }

        [JsonProperty("files", NullValueHandling = NullValueHandling.Ignore)]
        public IList<File> Files { get; set; } = new List<File>();

        [JsonExtensionData]
        public Dictionary<string,object> OtherFields { get; set; }

        public bool ShouldSerializeBlocks() => Blocks?.Any() ?? false;
        public bool ShouldSerializeAttachments() => Attachments?.Any() ?? false;
        public bool ShouldSerializeFiles() => Files?.Any() ?? false;
    }
}
