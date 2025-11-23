using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard.WebApi.SlackLists.Cells
{
    public class RatingCell : SlackListsCell
    {
        [JsonProperty("rating")]
        [JsonConverter(typeof(RatingCellConverter))]
        public int Rating { get; set; }
    }
}
