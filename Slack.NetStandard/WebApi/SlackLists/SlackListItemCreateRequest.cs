using Newtonsoft.Json;
using System.Collections.Generic;

namespace Slack.NetStandard.WebApi.SlackLists
{
    public class SlackListItemCreateRequest
    {
        [JsonProperty("list_id")]
        public string ListId { get; set; }

        [JsonProperty("parent_item_id")]
        public string ParentItemId { get; set; }

        [JsonProperty("duplicated_item_id")]
        public string DuplicatedItemId { get; set; }

        [JsonProperty("initial_fields")]
        public List<ISlackCellCreateDefinition> InitialFields { get; set; } = new List<ISlackCellCreateDefinition>();

        public bool ShouldSerializeInitialFields() => true;
    }
}
