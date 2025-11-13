using Newtonsoft.Json;
using System;

namespace Slack.NetStandard.WebApi.SlackLists.Cells
{
    public class DateCell: SlackListsCell
    {
        [AcceptedArray]
        [JsonProperty("date")]
        public DateTime[] Dates { get; set; }
    }
}
