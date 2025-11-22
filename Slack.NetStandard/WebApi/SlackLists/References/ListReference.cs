using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.SlackLists.References
{
    public class ListReference : SlackListsReference
    {
        public ListReference() { }

        public ListReference(string listId, string rowId)
        {
            ListId = listId;
            RowId = rowId;
        }

        [JsonProperty("list_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ListId { get; set; }

        [JsonProperty("row_id", NullValueHandling = NullValueHandling.Ignore)]
        public string RowId { get; set; }
    }
}
