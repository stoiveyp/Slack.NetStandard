using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Slack.NetStandard.WebApi.Admin;

internal class ChangeEntitiesRequest
{
    [JsonProperty("policy_name")] public string PolicyName { get; set; } = "email_password";

    [JsonProperty("entity_type", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public EntityType EntityType { get; set; } = EntityType.User;


    [JsonProperty("entity_ids")] public List<string> EntityIds { get; set; } = new();

    public bool ShouldSerializeEntityIds() => EntityIds?.Any() ?? false;
}