using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Linq;

namespace Slack.NetStandard.Messages.Elements.RichText
{
    public class ListElement : RichTextElement
    {
        public const string ElementName = "rich_text_list";
        public override string Type => ElementName;

        [JsonProperty("elements", NullValueHandling = NullValueHandling.Ignore)]
        public IList<RichTextElement> Elements { get; set; } = new List<RichTextElement>();

        [JsonProperty("style", NullValueHandling = NullValueHandling.Ignore)]
        public string Style { get; set; }

        [JsonProperty("indent", NullValueHandling = NullValueHandling.Ignore)]
        public int? Indent { get; set; }

        [JsonProperty("offset", NullValueHandling = NullValueHandling.Ignore)]
        public int? Offset { get; set; }

        [JsonProperty("border", NullValueHandling = NullValueHandling.Ignore)]
        public int? Border { get; set; }

        public bool ShouldSerializeElements() => Elements.Any();
    }
}
