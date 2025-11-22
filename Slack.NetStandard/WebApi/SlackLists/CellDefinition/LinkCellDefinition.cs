using Newtonsoft.Json;
using Slack.NetStandard.WebApi.SlackLists.Cells;
using System.Collections.Generic;

namespace Slack.NetStandard.WebApi.SlackLists.CellDefinition
{
    public class LinkCellDefinition:SlackListCellDefinition
    {
        public LinkCellDefinition(string columnId, string rowId = null) : base(columnId, rowId) { }

        public LinkCellDefinition(string columnId, List<SlackListsLink> links, string rowId = null) : this(columnId, rowId)
        {
            Links = links;
        }

        [JsonProperty("link")]
        public List<SlackListsLink> Links { get; private set; } = new();

        public bool ShouldSerializeLinks() => true;
    }
}
