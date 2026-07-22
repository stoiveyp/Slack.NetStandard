using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Slack.NetStandard.Messages.Elements;

namespace Slack.NetStandard.Messages.Blocks
{
    public class Alert : IMessageBlock
    {
        public const string MessageBlockType = "alert";
        [JsonProperty("type")] public string Type => MessageBlockType;

        public Alert() { }

        public Alert(TextObject text)
        {
            Text = text;
        }

        [JsonProperty("block_id", NullValueHandling = NullValueHandling.Ignore)]
        public string BlockId { get; set; }

        [JsonProperty("text")]
        public TextObject Text { get; set; }

        [JsonProperty("level", NullValueHandling = NullValueHandling.Ignore)]
        public AlertLevel? Level { get; set; }
    }
}
