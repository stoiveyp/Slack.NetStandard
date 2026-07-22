using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements.RichText
{
    public class TextElement: StyledRichTextElement
    {
        [JsonProperty("text",NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        public override string Type => ElementName;

        public const string ElementName = "text";
    }
}
