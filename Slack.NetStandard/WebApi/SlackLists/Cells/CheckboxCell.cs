using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard.WebApi.SlackLists.Cells
{
    public class CheckboxCell : SlackListsCell
    {
        [JsonProperty("checkbox")]
        [JsonConverter(typeof(SingleOrArrayConverter<bool>))]
        public bool Checkbox{ get; set; }
    }
}
