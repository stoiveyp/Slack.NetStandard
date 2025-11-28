using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;
using System.Collections.Generic;

namespace Slack.NetStandard.Messages.Blocks
{
    [JsonConverter(typeof(TableRowConverter))]
    public class TableRow
    {
        public List<ITableRowCell> Cells { get; set; } = new();
    }
}