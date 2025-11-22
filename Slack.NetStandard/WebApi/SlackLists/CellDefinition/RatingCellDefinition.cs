using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard.WebApi.SlackLists.CellDefinition
{
    public class RatingCellDefinition : SlackListCellDefinition
    {
        public RatingCellDefinition(string columnId, string rowId = null) : base(columnId, rowId) { }

        public RatingCellDefinition(string columnId, int rating, string rowId = null) : this(columnId, rowId)
        {
            Rating = rating;
        }

        [JsonProperty("rating")]
        [JsonConverter(typeof(SingleOrArrayConverter<int>), true)]
        public int Rating { get; set; }
    }
}
