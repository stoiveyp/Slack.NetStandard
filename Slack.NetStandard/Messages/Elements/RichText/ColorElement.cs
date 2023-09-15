using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements.RichText;

public class ColorElement : RichTextElement
{
    public const string ElementName = "color";

    [JsonProperty("value",NullValueHandling = NullValueHandling.Ignore)]
    public string Value { get; set; }
}