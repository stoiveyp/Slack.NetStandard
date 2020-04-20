using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Blocks
{
    public class UnknownBlock : IMessageBlock
    {
        [JsonProperty("type")]
        public string Type { get; }

        [JsonProperty("block_id")]
        public string BlockId { get; set; }

        [JsonExtensionData]
        public Dictionary<string,object> Fields { get; set; }
    }
}