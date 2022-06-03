using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Slack.NetStandard.Messages;
using Newtonsoft.Json.Converters;
using Slack.NetStandard.Messages.Blocks;

namespace Slack.NetStandard.WebApi.Chat
{
    public class UpdateMessageRequest
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("as_user", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AsUser { get; set; }

        [JsonProperty("ts")]
        public Timestamp Timestamp { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("blocks", NullValueHandling = NullValueHandling.Ignore)]
        public IList<IMessageBlock> Blocks { get; set; } = new List<IMessageBlock>();

        [JsonProperty("link_names", NullValueHandling = NullValueHandling.Ignore)]
        public bool? LinkNames { get; set; }

        [JsonProperty("file_ids", NullValueHandling = NullValueHandling.Ignore)]
        public string[] FileIds { get; set; }

        [JsonProperty("attachments", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Attachment> Attachments { get; set; } = new List<Attachment>();

        [JsonProperty("parse", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public MessageParsing MessageParsing { get; set; }

        public bool ShouldSerializeBlocks() => Blocks?.Any() ?? false;
        public bool ShouldSerializeAttachments() => Attachments?.Any() ?? false;
    }
}
