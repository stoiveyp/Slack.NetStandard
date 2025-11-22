using Newtonsoft.Json;
using System.Collections.Generic;

namespace Slack.NetStandard.WebApi.SlackLists.CellDefinition
{
    public class TimestampCellDefinition : SlackListCellDefinition
    {
        public TimestampCellDefinition(string columnId, string rowId = null) : base(columnId, rowId) { }

        public TimestampCellDefinition(string columnId, List<int> timestamps, string rowId = null) : this(columnId, rowId)
        {
            Timestamps = timestamps;
        }

        [JsonProperty("timestamp")]
        public List<int> Timestamps { get; private set; } = new();

        public bool ShouldSerializeTimestamps() => true;
    }
}
