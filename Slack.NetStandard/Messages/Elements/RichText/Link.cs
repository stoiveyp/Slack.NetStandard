using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements.RichText
{
    public class Link : RichTextElement
    {
        public const string ElementName = "link";

        [JsonProperty("url",NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        [JsonProperty("text",NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("style",NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,bool> Style { get; set; }
    }
}