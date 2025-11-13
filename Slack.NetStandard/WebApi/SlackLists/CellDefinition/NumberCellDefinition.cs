using Newtonsoft.Json;
using System.Collections.Generic;

namespace Slack.NetStandard.WebApi.SlackLists.CellDefinition
{
    internal class NumberCellDefinition:SlackListCellDefinition
    {
        public NumberCellDefinition(string columnId, string rowId = null) : base(columnId, rowId) { }

        public NumberCellDefinition(string columnId, List<int> numbers, string rowId = null) : this(columnId, rowId)
        {
            Numbers = numbers;
        }

        [JsonProperty("number")]
        public List<int> Numbers { get; private set; } = new();

        public bool ShouldSerializeNumbers() => true;
    }
}
