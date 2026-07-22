using System.Collections.Generic;
using Newtonsoft.Json;
using Slack.NetStandard.Messages.Elements;
using System.Linq;
using Slack.NetStandard.Messages.Elements.RichText;

namespace Slack.NetStandard.Messages.Blocks
{
    public class RichText:IMessageBlock
    {
        public RichText(){}

        public RichText(params RichTextElement[] elements)
        {
            Elements = elements;
        }

        [JsonProperty("type")] public string Type => MessageBlockType;

        [JsonProperty("block_id", NullValueHandling = NullValueHandling.Ignore)]
        public string BlockId { get; set; }

        [JsonProperty("elements", NullValueHandling = NullValueHandling.Ignore)]
        public IList<RichTextElement> Elements { get; set; } = new List<RichTextElement>();

        public const string MessageBlockType = "rich_text";

        public bool ShouldSerializeElements() => Elements.Any();
    }
}
