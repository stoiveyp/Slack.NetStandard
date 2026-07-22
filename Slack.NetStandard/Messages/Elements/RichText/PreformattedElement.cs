using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace Slack.NetStandard.Messages.Elements.RichText
{
    public class PreformattedElement : RichTextElement
    {
        public const string ElementName = "rich_text_preformatted";

        public override string Type => ElementName;

        [JsonProperty("elements", NullValueHandling = NullValueHandling.Ignore)]
        public IList<RichTextElement> Elements { get; set; } = new List<RichTextElement>();

        [JsonProperty("border", NullValueHandling = NullValueHandling.Ignore)]
        public int? Border { get; set; }

        [JsonProperty("language", NullValueHandling = NullValueHandling.Ignore)]
        public string Language { get; set; }

        public bool ShouldSerializeElements() => Elements.Any();
    }
}
