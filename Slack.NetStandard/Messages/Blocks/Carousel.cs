using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Blocks
{
    public class Carousel : IMessageBlock
    {
        public const string MessageBlockType = "carousel";
        [JsonProperty("type")] public string Type => MessageBlockType;

        public Carousel() { }

        public Carousel(params Card[] elements)
        {
            Elements = elements.ToList();
        }

        [JsonProperty("block_id", NullValueHandling = NullValueHandling.Ignore)]
        public string BlockId { get; set; }

        [JsonProperty("elements")]
        public IList<Card> Elements { get; set; } = new List<Card>();

        public bool ShouldSerializeElements() => true;
    }
}
