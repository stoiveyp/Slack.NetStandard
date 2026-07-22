using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.WorkObjects.Fields
{
    public class NumberEditOptions
    {
        [JsonProperty("min_value", NullValueHandling = NullValueHandling.Ignore)]
        public int? MinValue { get; set; }

        [JsonProperty("max_value", NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxValue { get; set; }
    }
}