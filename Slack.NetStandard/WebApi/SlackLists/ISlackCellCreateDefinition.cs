using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.SlackLists
{
    public interface ISlackCellCreateDefinition
    {
        [JsonProperty("column_id")]
        public string ColumnId { get; set; }
    }
}