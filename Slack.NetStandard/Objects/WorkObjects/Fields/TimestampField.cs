using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.WorkObjects.Fields
{
    public class TimestampField
    {
        [JsonProperty("value")]
        public long Value { get; set; }
    }
}