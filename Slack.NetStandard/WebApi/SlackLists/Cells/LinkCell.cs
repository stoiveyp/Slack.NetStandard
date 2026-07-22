using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.SlackLists.Cells
{
    public class LinkCell : SlackListsCell
    {
        [JsonProperty("link")]
        [AcceptedArray]
        public SlackListsLink[] Link { get; set; }
    }
}
