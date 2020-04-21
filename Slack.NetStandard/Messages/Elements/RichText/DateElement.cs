using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements.RichText
{
    public class DateElement : RichTextElement
    {
        public const string ElementName = "date";

        [JsonProperty("timestamp",NullValueHandling = NullValueHandling.Ignore)]
        public long Timestamp { get; set; }
    }
}