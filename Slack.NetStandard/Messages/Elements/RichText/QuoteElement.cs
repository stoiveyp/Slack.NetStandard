using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Linq;

namespace Slack.NetStandard.Messages.Elements.RichText
{
    public class QuoteElement : RichTextElement
    {
        public const string ElementName = "rich_text_quote";
        public override string Type => ElementName;

        [JsonProperty("elements", NullValueHandling = NullValueHandling.Ignore)]
        public IList<RichTextElement> Elements { get; set; } = new List<RichTextElement>();

        [JsonProperty("border", NullValueHandling = NullValueHandling.Ignore)]
        public int? Border { get; set; }

        public bool ShouldSerializeElements() => Elements.Any();
    }
}
