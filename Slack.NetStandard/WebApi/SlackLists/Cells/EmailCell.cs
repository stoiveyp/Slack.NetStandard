using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.SlackLists.Cells
{
    public class EmailCell : SlackListsCell
    {
        [AcceptedArray]
        [JsonProperty("email")]
        public string[] Email { get; set; }
    }
}
