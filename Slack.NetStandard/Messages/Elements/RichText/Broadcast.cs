using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements.RichText
{
    public class Broadcast : RichTextElement
    {
        public const string ElementName = "broadcast";

        [JsonProperty("range",NullValueHandling = NullValueHandling.Ignore)]
        public string Range { get; set; }

        public override string Type => ElementName;
    }
}