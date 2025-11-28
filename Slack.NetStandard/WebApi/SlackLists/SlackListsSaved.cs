using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Slack.NetStandard.WebApi.SlackLists
{
    public class SlackListsSaved
    {
        [JsonProperty("is_archived")]
        public bool IsArchived { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public SlackListsSavedState State { get; set; }

        [JsonProperty("date_due", NullValueHandling = NullValueHandling.Ignore)]
        public long? DateDue { get; set; }

        [JsonProperty("date_completed", NullValueHandling = NullValueHandling.Ignore)]
        public long? DateCompleted { get; set; }
    }
}
