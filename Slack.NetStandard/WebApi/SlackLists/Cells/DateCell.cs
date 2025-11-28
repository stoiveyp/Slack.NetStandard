using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;
using System;

namespace Slack.NetStandard.WebApi.SlackLists.Cells
{
    public class DateCell: SlackListsCell
    {
        [AcceptedArray]
        [JsonProperty("date")]
        [JsonConverter(typeof(CellDateConverter))]
        public DateTime[] Dates { get; set; }
    }
}
