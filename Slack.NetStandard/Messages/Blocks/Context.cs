using System.Collections.Generic;
using Newtonsoft.Json;
using Slack.NetStandard.Messages.Elements;

namespace Slack.NetStandard.Messages.Blocks
{
    public class Context : IMessageBlock
    {
        public string Type => nameof(Context).ToLower();

        [JsonProperty("elements", NullValueHandling = NullValueHandling.Ignore)]
        public IList<IContextElement> Elements { get; set; }

        [JsonProperty("block_id", NullValueHandling = NullValueHandling.Ignore)]
        public string BlockId { get; set; }
    }
}