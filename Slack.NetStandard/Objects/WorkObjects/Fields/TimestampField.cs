using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.WorkObjects.Fields
{
    public class TimestampField : EntityPayloadField
    {
        public const string TypeName = "slack#/types/timestamp";

        [JsonProperty("type")]
        public override string Type => TypeName;

        [JsonProperty("value")]
        public long Value { get; set; }
    }
}