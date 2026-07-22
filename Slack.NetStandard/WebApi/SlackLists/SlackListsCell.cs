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

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }


        [JsonExtensionData]
        public Dictionary<string, object> OtherFields { get; set; } = new();
    }
}
