using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.SlackLists.Cells
{
    public class MessageCell : SlackListsCell
    {
        [JsonProperty("message")]
        [AcceptedArray]
        public SlackListsMessageInfo[] Link { get; set; }
    }
}
