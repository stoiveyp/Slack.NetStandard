using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Slack.NetStandard.WebApi.Admin;

public class Entity
{
    [JsonProperty("entity_type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public EntityType EntityType { get; set; }

    [JsonProperty("entity_id")]
    public string EntityId { get; set; }

    [JsonProperty("date_added")]
    public long DateAdded { get; set; }
}