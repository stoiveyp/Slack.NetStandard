using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Slack.NetStandard.Messages.Elements.RichText;
using System.Linq;

namespace Slack.NetStandard.Messages.Elements
{
    public class RichTextList : IMessageElement
    {
        public const string ElementType = "rich_text_list";
        public string Type => ElementType;

        [JsonProperty("elements", NullValueHandling = NullValueHandling.Ignore)]
        public IList<RichTextElement> Elements { get; set; } = new List<RichTextElement>();

        [JsonProperty("style", NullValueHandling = NullValueHandling.Ignore)]
        public string Style { get; set; }

        [JsonProperty("indent", NullValueHandling = NullValueHandling.Ignore)]
        public int? Indent { get; set; }

        public bool ShouldSerializeElements() => Elements.Any();
    }
}
