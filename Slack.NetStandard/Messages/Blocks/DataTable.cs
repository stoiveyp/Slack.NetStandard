using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Blocks
{
    public class DataTable : IMessageBlock
    {
        public const string MessageBlockType = "data_table";
        [JsonProperty("type")] public string Type => MessageBlockType;

        public DataTable() { }

        public DataTable(string caption)
        {
            Caption = caption;
        }

        [JsonProperty("block_id", NullValueHandling = NullValueHandling.Ignore)]
        public string BlockId { get; set; }

        [JsonProperty("caption", NullValueHandling = NullValueHandling.Ignore)]
        public string Caption { get; set; }

        [JsonProperty("page_size", NullValueHandling = NullValueHandling.Ignore)]
        public int? PageSize { get; set; }

        [JsonProperty("row_header_column_index", NullValueHandling = NullValueHandling.Ignore)]
        public int? RowHeaderColumnIndex { get; set; }

        [JsonProperty("rows", NullValueHandling = NullValueHandling.Ignore)]
        public List<TableRow> Rows { get; set; } = new List<TableRow>();

        public bool ShouldSerializeRows() => Rows?.Any() ?? false;
    }
}
