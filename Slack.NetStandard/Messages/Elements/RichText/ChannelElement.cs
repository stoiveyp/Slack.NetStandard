using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements.RichText
{
    public class ChannelElement : RichTextElement
    {
        public const string ElementName = "channel";

        [JsonProperty("channel",NullValueHandling = NullValueHandling.Ignore)]
        public string Channel { get; set; }
    }
}