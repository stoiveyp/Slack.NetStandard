using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements.RichText
{
    public class TextElement:RichTextElement
    {
        [JsonProperty("text",NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("style",NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,bool> Style { get; set; }

        public const string ElementName = "text";
    }
}
