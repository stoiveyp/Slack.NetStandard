using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Slack.NetStandard.Messages.Elements;

namespace Slack.NetStandard.Messages.Blocks
{
    public class Section:IMessageBlock
    {
        [JsonProperty("type")] public string Type => nameof(Section).ToLower();

        [JsonProperty("text",NullValueHandling = NullValueHandling.Ignore)]
        public TextObject Text { get; set; }

        [JsonProperty("block_id",NullValueHandling = NullValueHandling.Ignore)]
        public string BlockId { get; set; }

        [JsonProperty("fields",NullValueHandling = NullValueHandling.Ignore)]
        public IList<TextObject> Fields { get; set; }

        [JsonProperty("accessory",NullValueHandling = NullValueHandling.Ignore)]
        public IMessageElement Accessory { get; set; }
    }
}
