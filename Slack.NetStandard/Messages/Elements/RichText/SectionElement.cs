using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Linq;

namespace Slack.NetStandard.Messages.Elements.RichText
{
    public class SectionElement:RichTextElement
    {
        public const string ElementName = "rich_text_section";
        public override string Type => ElementName;

        [JsonProperty("elements",NullValueHandling = NullValueHandling.Ignore)]
        public IList<RichTextElement> Elements { get; set; } = new List<RichTextElement>();

        public bool ShouldSerializeElements() => Elements.Any();
    }
}
