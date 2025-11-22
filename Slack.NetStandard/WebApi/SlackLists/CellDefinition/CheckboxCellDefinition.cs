using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.SlackLists.CellDefinition
{
    public class CheckboxCellDefinition : SlackListsCellDefinition
    {
        public CheckboxCellDefinition(string columnId, string rowId = null) : base(columnId, rowId) { }

        public CheckboxCellDefinition(string columnId, bool checkbox, string rowId = null) : this(columnId, rowId)
        {
            Checkbox = checkbox;
        }

        [JsonProperty("checkbox")]
        public bool Checkbox { get; set; }
    }
}
