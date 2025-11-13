using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Slack.NetStandard.WebApi.SlackLists.Cells
{
    public class NumberCell : SlackListsCell
    {
        [AcceptedArray]
        [JsonProperty("number")]
        public string[] Numers { get; set; }
    }
}
