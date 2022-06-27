using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Blocks
{
    public class Context : IMessageBlock
    {
        public Context(){}

        public Context(params IContextElement[] elements)
        {
            Elements = elements.ToList();
        }

        public string Type => nameof(Context).ToLower();

        [JsonProperty("elements", NullValueHandling = NullValueHandling.Ignore)]
        public IList<IContextElement> Elements { get; set; } = new List<IContextElement>();

        [JsonProperty("block_id", NullValueHandling = NullValueHandling.Ignore)]
        public string BlockId { get; set; }

        public bool ShouldSerializeElements() => Elements.Any();
    }
}