using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Slack.NetStandard.Messages.Blocks;

namespace Slack.NetStandard.Messages
{
    public class Attachment
    {
        [JsonProperty("blocks", NullValueHandling = NullValueHandling.Ignore)]
        public List<IMessageBlock> Blocks { get; set; } = new ();

        [JsonProperty("color",NullValueHandling = NullValueHandling.Ignore)]
        public string Color { get; set; }

        [JsonProperty("author_icon",NullValueHandling = NullValueHandling.Ignore)]
        public string AuthorIcon { get; set; }

        [JsonProperty("author_link",NullValueHandling = NullValueHandling.Ignore)]
        public string AuthorLink { get; set; }

        [JsonProperty("author_name",NullValueHandling = NullValueHandling.Ignore)]
        public string AuthorName { get; set; }

        [JsonProperty("fallback",NullValueHandling = NullValueHandling.Ignore)]
        public string Fallback { get; set; }

        [JsonProperty("fields",NullValueHandling = NullValueHandling.Ignore)]
        public List<AttachmentField> Fields { get; set; } = new List<AttachmentField>();

        [JsonProperty("footer",NullValueHandling = NullValueHandling.Ignore)]
        public string Footer { get; set; }

        [JsonProperty("footer_icon",NullValueHandling = NullValueHandling.Ignore)]
        public string FooterIcon { get; set; }

        [JsonProperty("image_url",NullValueHandling = NullValueHandling.Ignore)]
        public string ImageUrl { get; set; }

        [JsonProperty("mrkdwn_in",NullValueHandling = NullValueHandling.Ignore)]
        public List<string> MarkdownIn { get; set; } = new ();

        [JsonProperty("pretext",NullValueHandling = NullValueHandling.Ignore)]
        public string Pretext { get; set; }

        [JsonProperty("text",NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("thumb_url",NullValueHandling = NullValueHandling.Ignore)]
        public string ThumbUrl { get; set; }

        [JsonProperty("title",NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("title_link",NullValueHandling = NullValueHandling.Ignore)]
        public string TitleLink { get; set; }

        [JsonProperty("ts",NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp Timestamp { get; set; }



        [JsonExtensionData]
        public Dictionary<string, object> OtherFields { get; set; }

        public bool ShouldSerializeBlocks() => Blocks?.Any() ?? false;
        public bool ShouldSerializeFields() => Fields?.Any() ?? false;
        public bool ShouldSerializeMarkdownIn() => MarkdownIn?.Any() ?? false;
    }
}
