using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.WorkObjects
{
    public class EntityPayloadFieldTimestamp
    {
        [JsonProperty("value")]
        public long Value { get; set; }
    }
}