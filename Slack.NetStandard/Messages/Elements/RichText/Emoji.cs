using Newtonsoft.Json;
using System.Collections.Generic;

namespace Slack.NetStandard.Messages.Elements.RichText
{
    public class Emoji : StyledRichTextElement
    {
        public const string ElementName = "emoji";

        [JsonProperty("name",NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("skinTone",NullValueHandling = NullValueHandling.Ignore)]
        public int? SkinTone { get; set; }

        [JsonProperty("unicode",NullValueHandling = NullValueHandling.Ignore)]
        public string Unicode { get; set; }

        public override string Type => ElementName;
    }
}