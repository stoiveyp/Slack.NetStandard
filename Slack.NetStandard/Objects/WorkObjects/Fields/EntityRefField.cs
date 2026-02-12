using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.WorkObjects.Fields;

public class EntityRefField: EntityPayloadField
{
    public const string TypeName = "slack#/types/entity_ref";

    [JsonProperty("type")]
    public override string Type => TypeName;

    [JsonProperty("entity_url")]
    public string EntityUrl { get; set; }

    [JsonProperty("external_ref")]
    public ExternalRef ExternalRef { get; set; }

    [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
    public string Title { get; set; }

    [JsonProperty("display_type", NullValueHandling = NullValueHandling.Ignore)]
    public string DisplayType { get; set; }

    [JsonProperty("Icon", NullValueHandling = NullValueHandling.Ignore)]
    public EntityPayloadIcon Icon { get; set; }
}
