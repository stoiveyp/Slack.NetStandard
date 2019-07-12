using System.Collections.Generic;
using Newtonsoft.Json;
using Slack.NetStandard.Messages.Elements;

namespace Slack.NetStandard.Messages.Blocks
{
    public class Actions : IMessageBlock
    {
        public string Type => nameof(Actions).ToLower();

        [JsonProperty("block_id",NullValueHandling = NullValueHandling.Ignore)]
        public string BlockId { get; set; }

        [JsonProperty("elements",NullValueHandling = NullValueHandling.Ignore)]
        public IList<IMessageElement> Elements { get; set; }
    }
}