using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Slack.NetStandard.Messages.Elements;
using System.Linq;

namespace Slack.NetStandard.Messages.Blocks
{
    public class RichText:IMessageBlock
    {
        public RichText(){}

        public RichText(params IMessageElement[] elements)
        {
            Elements = elements;
        }

        [JsonProperty("type")] public string Type => MessageBlockType;

        [JsonProperty("block_id", NullValueHandling = NullValueHandling.Ignore)]
        public string BlockId { get; set; }

        [JsonProperty("elements", NullValueHandling = NullValueHandling.Ignore)]
        public IList<IMessageElement> Elements { get; set; } = new List<IMessageElement>();

        public const string MessageBlockType = "rich_text";

        public bool ShouldSerializeElements() => Elements.Any();
    }
}
