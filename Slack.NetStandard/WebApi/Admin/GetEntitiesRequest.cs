using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Slack.NetStandard.WebApi.Admin
{
    public class GetEntitiesRequest
    {
        [JsonProperty("policy_name")] public string PolicyName { get; set; } = "email_password";

        [JsonProperty("entity_type", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public EntityType EntityType { get; set; } = EntityType.User;

        [JsonProperty("cursor",NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; set; }

        [JsonProperty("limit",NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; set; }
    }
}
