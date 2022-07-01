using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Slack.NetStandard.Messages.Elements;

namespace Slack.NetStandard.Messages.Blocks
{
    public class Section:IMessageBlock
    {
        public Section() { }

        public Section(string plainText):this(new PlainText(plainText))
        {

        }

        public Section(TextObject text)
        {
            Text = text;
        }

        public Section(params TextObject[] fields)
        {
            Fields = fields.ToList();
        }
        [JsonProperty("type")] public string Type => nameof(Section).ToLower();

        [JsonProperty("text",NullValueHandling = NullValueHandling.Ignore)]
        public TextObject Text { get; set; }

        [JsonProperty("block_id",NullValueHandling = NullValueHandling.Ignore)]
        public string BlockId { get; set; }

        [JsonProperty("fields",NullValueHandling = NullValueHandling.Ignore)]
        public IList<TextObject> Fields { get; set; } = new List<TextObject>();

        [JsonProperty("accessory",NullValueHandling = NullValueHandling.Ignore)]
        public IMessageElement Accessory { get; set; }

        public bool ShouldSerializeFields() => Fields.Any();
    }
}
