using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.SlackLists.Cells
{
    public class ChannelCell : SlackListsCell
    {
        [AcceptedArray]
        [JsonProperty("channel")]
        public string[] Channel { get; set; }
    }
}
