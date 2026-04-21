using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slack.NetStandard.Messages.Blocks;
using Slack.NetStandard.Messages.Elements;
using System.Linq;

namespace Slack.NetStandard.Messages.StreamChunks;

public class BlocksChunk : IStreamChunk
{
    public BlocksChunk(params IMessageBlock[] blocks)
    {
        Blocks = blocks.ToList();
    }
    
    public const string ElementType = "blocks";
    
    [JsonProperty("type")]
    public string Type => ElementType;
    
    
    [JsonProperty("blocks", NullValueHandling = NullValueHandling.Ignore)]
    public IList<IMessageBlock> Blocks { get; set; } = new List<IMessageBlock>();
    
    public bool ShouldSerializeBlocks() => Blocks?.Any() ?? false;
}