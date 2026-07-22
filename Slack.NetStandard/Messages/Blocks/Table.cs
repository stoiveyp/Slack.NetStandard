using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Slack.NetStandard.Messages.Blocks
{
    public class Table : IMessageBlock
    {
        public Table()
        {
        }

        public Table(string blockId)
        {
            BlockId = blockId;
        }

        [JsonProperty("type")]
        public string Type => nameof(Table).ToLower();

        [JsonProperty("block_id", NullValueHandling = NullValueHandling.Ignore)]
        public string BlockId { get; set; }

        [JsonProperty("column_settings", NullValueHandling = NullValueHandling.Ignore)]
        public List<TableColumnSetting> ColumnSettings { get; set; } = new();

        [JsonProperty("rows", NullValueHandling = NullValueHandling.Ignore)]
        public List<TableRow> Rows { get; set; } = new();

        public bool ShouldSerializeColumnSettings() => ColumnSettings?.Any() ?? false;
        public bool ShouldSerializeRows() => Rows?.Any() ?? false;
    }
}
