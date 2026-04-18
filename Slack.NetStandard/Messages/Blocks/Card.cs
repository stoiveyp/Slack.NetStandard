using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Slack.NetStandard.Messages.Elements;

namespace Slack.NetStandard.Messages.Blocks
{
    public class Card : IMessageBlock
    {
        public const string MessageBlockType = "card";
        [JsonProperty("type")] public string Type => MessageBlockType;

        public Card() { }

        public Card(TextObject title)
        {
            Title = title;
        }

        [JsonProperty("block_id", NullValueHandling = NullValueHandling.Ignore)]
        public string BlockId { get; set; }

        [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
        public Image Icon { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public TextObject Title { get; set; }

        [JsonProperty("subtitle", NullValueHandling = NullValueHandling.Ignore)]
        public TextObject Subtitle { get; set; }

        [JsonProperty("hero_image", NullValueHandling = NullValueHandling.Ignore)]
        public Image HeroImage { get; set; }

        [JsonProperty("body", NullValueHandling = NullValueHandling.Ignore)]
        public TextObject Body { get; set; }

        [JsonProperty("actions", NullValueHandling = NullValueHandling.Ignore)]
        public IList<IMessageElement> Actions { get; set; } = new List<IMessageElement>();

        public bool ShouldSerializeActions() => Actions?.Any() ?? false;
    }
}
