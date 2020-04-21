using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements.RichText
{
    public class Emoji : RichTextElement
    {
        [JsonProperty("name",NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        public const string ElementName = "emoji";
    }
}