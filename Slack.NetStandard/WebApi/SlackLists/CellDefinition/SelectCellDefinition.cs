using Newtonsoft.Json;
using System.Collections.Generic;

namespace Slack.NetStandard.WebApi.SlackLists.CellDefinition
{
    public class SelectCellDefinition : SlackListCellDefinition
    {
        public SelectCellDefinition(string columnId, string rowId = null) : base(columnId, rowId) { }

        public SelectCellDefinition(string columnId, List<string> optionIds, string rowId = null) : this(columnId, rowId)
        {
            OptionIds = optionIds;
        }

        [JsonProperty("select")]
        public List<string> OptionIds { get; private set; } = new();

        public bool ShouldSerializeOptionIds() => true;
    }
}
