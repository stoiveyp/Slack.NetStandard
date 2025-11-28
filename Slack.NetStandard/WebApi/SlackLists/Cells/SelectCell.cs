using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Slack.NetStandard.WebApi.SlackLists.Cells
{
    public class SelectCell : SlackListsCell
    {
        [AcceptedArray]
        [JsonProperty("select")]
        public string[] OptionIds { get; set; }
    }
}
