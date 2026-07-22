using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Slack.NetStandard.WebApi.SlackLists.Cells
{
    public class TimestampCell : SlackListsCell
    {
        [AcceptedArray]
        [JsonProperty("timestamp")]
        public long[] Timestamps { get; set; }
    }
}
