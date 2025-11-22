using Newtonsoft.Json;
using System.Collections.Generic;

namespace Slack.NetStandard.WebApi.SlackLists.CellDefinition
{
    public class ChannelCellDefinition : SlackListCellDefinition
    {
        public ChannelCellDefinition(string columnId, string rowId = null) : base(columnId, rowId) { }

        public ChannelCellDefinition(string columnId, List<string> channels, string rowId = null) : this(columnId, rowId)
        {
            Channels = channels;
        }

        [JsonProperty("channel")]
        public List<string> Channels { get; private set; } = new();

        public bool ShouldSerializeChannels() => true;
    }
}
