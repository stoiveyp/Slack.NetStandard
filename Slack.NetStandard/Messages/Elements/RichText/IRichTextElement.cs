using System.Collections.Generic;
using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard.Messages.Elements.RichText
{
    [JsonConverter(typeof(RichTextElementConverter))]
    public abstract class RichTextElement
    {
        [JsonProperty("type")]
        public abstract string Type { get; }

        [JsonExtensionData]
        public Dictionary<string, object> OtherFields { get; set; }
    }

    public abstract class StyledRichTextElement:RichTextElement
    {
        [JsonProperty("style", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, bool> Style { get; set; }
    }

    public class UnknownRichTextElement : RichTextElement
    {
        public override string Type {get; }
    }
}
