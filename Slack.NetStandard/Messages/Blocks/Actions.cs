using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Slack.NetStandard.Messages.Elements;

namespace Slack.NetStandard.Messages.Blocks
{
    public class Actions : IMessageBlock
    {
        public Actions(){}

        public Actions(params IMessageElement[] elements)
        {
            Elements = elements.ToList();
        }

        public string Type => nameof(Actions).ToLower();

        [JsonProperty("block_id",NullValueHandling = NullValueHandling.Ignore)]
        public string BlockId { get; set; }

        [JsonProperty("elements",NullValueHandling = NullValueHandling.Ignore)]
        public IList<IMessageElement> Elements { get; set; }
    }
}