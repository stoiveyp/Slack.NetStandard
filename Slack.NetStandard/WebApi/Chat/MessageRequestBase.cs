using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slack.NetStandard.Messages;
using Slack.NetStandard.Messages.Blocks;

namespace Slack.NetStandard.WebApi.Chat
{
    public abstract class MessageRequestBase {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("as_user", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AsUser { get; set; }

        [JsonProperty("blocks", NullValueHandling = NullValueHandling.Ignore)]
        public IList<IMessageBlock> Blocks { get; set; } = new List<IMessageBlock>();

        [JsonProperty("icon_emoji", NullValueHandling = NullValueHandling.Ignore)]
        public string IconEmoji { get; set; }

        [JsonProperty("icon_url", NullValueHandling = NullValueHandling.Ignore)]
        public string IconUrl { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("link_names",NullValueHandling = NullValueHandling.Ignore)]
        public bool? LinkNames { get; set; }

        [JsonProperty("thread_ts", NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp ThreadId { get; set; }

        [JsonProperty("parse",NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public MessageParsing MessageParsing { get; set; }

        [JsonProperty("username",NullValueHandling = NullValueHandling.Ignore)]
        public string Username { get; set; }

        [JsonProperty("attachments", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Attachment> Attachments { get; set; } = new List<Attachment>();

        [JsonProperty("metadata",NullValueHandling = NullValueHandling.Ignore)]
        public MessageMetadata Metadata { get; set; }

        public bool ShouldSerializeBlocks() => Blocks?.Any() ?? false;
        public bool ShouldSerializeAttachments() => Attachments?.Any() ?? false;
    }
}