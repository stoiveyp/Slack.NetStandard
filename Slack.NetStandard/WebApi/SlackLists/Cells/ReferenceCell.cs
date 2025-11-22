using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.SlackLists.Cells
{
    public class ReferenceCell : SlackListsCell
    {
        [JsonProperty("reference")]
        [AcceptedArray]
        public SlackListsReference[] Reference { get; set; }
    }
}
