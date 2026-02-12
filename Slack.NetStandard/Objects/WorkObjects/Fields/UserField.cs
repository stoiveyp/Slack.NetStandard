using Newtonsoft.Json;
using System.Diagnostics.Contracts;

namespace Slack.NetStandard.Objects.WorkObjects.Fields
{
    public class UserField : EntityPayloadField
    {
        public const string TypeName = "slack#/types/user";

        [JsonProperty("user")]
        public EntityPayloadFieldInnerUser User { get; set; }

        [JsonProperty("type")]
        public override string Type => TypeName;
    }
}