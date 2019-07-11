using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.MessageBlocks
{
    public class Divider:IMessageBlock
    {
        public Divider() { }

        public Divider(string blockId)
        {
            BlockId = blockId;
        }
        [JsonProperty("type")] public string Type => "divider";

        [JsonProperty("block_id",NullValueHandling = NullValueHandling.Ignore)]
        public string BlockId { get; set; }
    }
}
