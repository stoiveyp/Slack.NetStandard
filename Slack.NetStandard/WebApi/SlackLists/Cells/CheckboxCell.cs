using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard.WebApi.SlackLists.Cells
{
    public class CheckboxCell : SlackListsCell
    {
        [JsonProperty("checkbox")]
        public bool Checkbox{ get; set; }
    }
}
