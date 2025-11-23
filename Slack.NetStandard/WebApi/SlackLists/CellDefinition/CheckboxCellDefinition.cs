using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;

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
        [JsonConverter(typeof(CheckboxCellConverter))]
        public bool Checkbox { get; set; }
    }
}
