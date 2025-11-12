using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;
using System.Collections.Generic;

namespace Slack.NetStandard.WebApi.SlackLists
{
    [JsonConverter(typeof(SlackListsCellConverter))]
    public class SlackListsCell
    {
        [JsonProperty("column_id")]
        public string ColumnId { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> OtherFields { get; set; } = new();
    }
}
