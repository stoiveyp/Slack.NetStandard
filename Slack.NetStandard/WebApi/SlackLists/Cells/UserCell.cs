using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Slack.NetStandard.WebApi.SlackLists.Cells
{
    public class UserCell:SlackListsCell
    {
        [AcceptedArray]
        [JsonProperty("users")]
        public string[] Users { get; set; }
    }
}
