using Newtonsoft.Json;
using System.Collections.Generic;

namespace Slack.NetStandard.WebApi.SlackLists
{
    public class SlackListsItemCreateRequest
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

    internal class SlackListsItemUpdateRequest
    {
        public SlackListsItemUpdateRequest() { }
        public SlackListsItemUpdateRequest(string listId, List<ISlackCellUpdateDefinition> cells)
        {
            ListId = listId;
            Cells = cells;
        }

        [JsonProperty("list_id")]
        public string ListId { get; set; }

        [JsonProperty("cells")]
        public List<ISlackCellUpdateDefinition> Cells { get; set; } = new List<ISlackCellUpdateDefinition>();

        public bool ShouldSerializeCells() => true;
    }
}
