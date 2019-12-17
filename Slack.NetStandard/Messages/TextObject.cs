using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;
using Slack.NetStandard.Messages.Blocks;

namespace Slack.NetStandard.Messages
{
    [JsonConverter(typeof(TextObjectConverter))]
    public abstract class TextObject:IContextElement
    {
        protected TextObject() { }

        protected TextObject(string text)
        {
            Text = text;
        }

        [JsonProperty("type")] public abstract TextType Type { get; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("emoji",NullValueHandling = NullValueHandling.Ignore)]
        public bool? Emoji { get; set; }

        [JsonProperty("verbatim",NullValueHandling = NullValueHandling.Ignore)]
        public bool? Verbatim { get; set; }
    }
}
