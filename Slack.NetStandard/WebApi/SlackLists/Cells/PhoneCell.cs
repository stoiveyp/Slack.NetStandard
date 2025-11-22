using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.SlackLists.Cells
{
    public class PhoneCell : SlackListsCell
    {
        [AcceptedArray]
        [JsonProperty("phone")]
        public string[] PhoneNumbers { get; set; }
    }
}
