using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Slack.NetStandard.Messages.Blocks
{
    public class Container : IMessageBlock
    {
        public const string MessageBlockType = "container";
        [JsonProperty("type")] public string Type => MessageBlockType;

        public Container() { }

        public Container(string title, params IMessageBlock[] childBlocks)
        {
            Title = new PlainText(title);
            ChildBlocks = childBlocks.ToList();
        }
        
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public PlainText Title { get; set; }
        
        [JsonProperty("subtitle", NullValueHandling = NullValueHandling.Ignore)]
        public TextObject Subtitle { get; set; }
        
        [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
        public SlackContainerWidth? Width { get; set; }
        

        [JsonProperty("block_id", NullValueHandling = NullValueHandling.Ignore)]
        public string BlockId { get; set; }

        [JsonProperty("child_blocks", NullValueHandling = NullValueHandling.Ignore)]
        public List<IMessageBlock> ChildBlocks { get; set; } = new List<IMessageBlock>();
        
        public bool ShouldSerializeChildBlocks() => ChildBlocks?.Any() ?? false;
        
        [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
        public Image Icon { get; set; }

        [JsonProperty("is_collapsible", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsCollapsible { get; set; }
        
        [JsonProperty("default_collapsed", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DefaultCollapsed { get; set; }
        
    }
    
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SlackContainerWidth
    {
        [EnumMember(Value = "narrow")] Narrow,
        [EnumMember(Value = "standard")] Standard,
        [EnumMember(Value = "wide")] Wide,
        [EnumMember(Value = "full")] Full
    }
}
