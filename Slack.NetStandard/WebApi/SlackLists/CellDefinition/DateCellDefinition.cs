using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;
using System;
using System.Collections.Generic;

namespace Slack.NetStandard.WebApi.SlackLists.CellDefinition
{
    public class DateCellDefinition : SlackListsCellDefinition
    {
        public DateCellDefinition(string columnId, string rowId = null) : base(columnId, rowId) { }

        public DateCellDefinition(string columnId, List<DateTime> dates, string rowId = null) : this(columnId, rowId)
        {
            Dates = dates;
        }

        [JsonProperty("date")]
        [JsonConverter(typeof(CellDateConverter))]
        public List<DateTime> Dates { get; private set; } = new();

        public bool ShouldSerializeDates() => true;
    }
}
