using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Slack.NetStandard.Messages.Blocks
{
    public class Callout : IMessageBlock
    {
        public const string MessageBlockType = "callout";
        [JsonProperty("type")] public string Type => MessageBlockType;

        public Callout() { }

        public Callout(CalloutColor backgroundColor, params IMessageBlock[] childBlocks)
        {
            BackgroundColor = backgroundColor;
            ChildBlocks = childBlocks.ToList();
        }
        
        [JsonProperty("background_color", NullValueHandling = NullValueHandling.Ignore)]
        public CalloutColor? BackgroundColor { get; set; }

        [JsonProperty("block_id", NullValueHandling = NullValueHandling.Ignore)]
        public string BlockId { get; set; }

        [JsonProperty("child_blocks", NullValueHandling = NullValueHandling.Ignore)]
        public List<IMessageBlock> ChildBlocks { get; set; } = new List<IMessageBlock>();
        
        public bool ShouldSerializeChildBlocks() => ChildBlocks?.Any() ?? false;
        
    }
    
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CalloutColor
    {
        [EnumMember(Value = "indigo")] Indigo,
        [EnumMember(Value = "blue")] Blue,
        [EnumMember(Value = "jade")] Jade,
        [EnumMember(Value = "pink")] Pink,
        [EnumMember(Value = "gray")] Gray,
        [EnumMember(Value = "purple")] Purple,
        [EnumMember(Value = "orange")] Orange,
        [EnumMember(Value = "brown")] Brown,
        [EnumMember(Value = "green")] Green
    }
}
