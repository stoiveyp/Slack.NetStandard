using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.SlackLists
{
    internal interface ISlackCellUpdateDefinition
    {
        [JsonProperty("column_id")]
        public string ColumnId { get; set; }

        [JsonProperty("row_id", NullValueHandling = NullValueHandling.Ignore)]
        public string RowId { get; set; }
    }
}