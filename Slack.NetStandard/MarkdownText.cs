using Newtonsoft.Json;

namespace Slack.NetStandard
{
    public class MarkdownText : TextObject
    {
        public MarkdownText() { }

        public MarkdownText(string text) : base(text) { }
        public override TextType Type => TextType.Markdown;

        [JsonProperty("verbatim", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Verbatim { get; set; }
    }
}