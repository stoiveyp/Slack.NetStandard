using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;
using System.Collections.Generic;

namespace Slack.NetStandard.Objects.Reactions
{
    [JsonConverter(typeof(ReactionItemConverter))]
    public class ReactionItem
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        public long Created { get; set; }

        [JsonProperty("created_by", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedBy { get; set; }

        [JsonProperty("channel", NullValueHandling = NullValueHandling.Ignore)]
        public string Channel { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> OtherFields { get; set; }
    }
}
