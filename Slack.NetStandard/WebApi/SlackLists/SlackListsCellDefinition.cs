using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;
using System.Collections.Generic;

namespace Slack.NetStandard.WebApi.SlackLists
{
    [JsonConverter(typeof(SlackListsCellDefinitionConverter))]
    public class SlackListsCellDefinition : ISlackCellCreateDefinition, ISlackCellUpdateDefinition
    {
        public SlackListsCellDefinition(string columnId, string rowId = null)
        { 
            ColumnId = columnId;
            RowId = rowId;
        }

        [JsonProperty("column_id")]
        public string ColumnId { get; set; }

        [JsonProperty("row_id", NullValueHandling = NullValueHandling.Ignore)]
        public string RowId { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> OtherFields { get; set; } = new();
    }
}
