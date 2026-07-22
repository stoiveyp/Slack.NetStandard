using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.WorkObjects.Fields
{
    public class ChannelField : EntityPayloadField
    {
        public const string TypeName = "slack#/types/channel";

        [JsonProperty("type")] 
        public override string Type => TypeName;

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}