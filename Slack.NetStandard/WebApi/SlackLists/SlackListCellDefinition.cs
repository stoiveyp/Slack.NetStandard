using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.SlackLists
{
    public class SlackListCellDefinition : ISlackCellCreateDefinition, ISlackCellUpdateDefinition
    {
        public SlackListCellDefinition(string columnId, string rowId = null)
        { }

        [JsonProperty("column_id")]
        public string ColumnId { get; set; }

        [JsonProperty("row_id", NullValueHandling = NullValueHandling.Ignore)]
        public string RowId { get; set; }
    }
}
