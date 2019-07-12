using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Blocks
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
