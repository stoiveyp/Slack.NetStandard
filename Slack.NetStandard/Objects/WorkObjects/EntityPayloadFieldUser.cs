using Newtonsoft.Json;
using System.Diagnostics.Contracts;

namespace Slack.NetStandard.Objects.WorkObjects
{
    public class EntityPayloadFieldUser
    {
        [JsonProperty("user")]
        public EntityPayloadFieldInnerUser User { get; set; }

        [JsonProperty("type")]
        public string Type => "slack#/types/user";
    }
}