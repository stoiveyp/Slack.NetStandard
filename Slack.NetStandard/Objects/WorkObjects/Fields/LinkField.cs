using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.WorkObjects.Fields;

public class LinkField : EntityPayloadField
{
    public const string TypeName = "slack#/types/link";

    [JsonProperty("type")]
    public override string Type => TypeName;

    [JsonProperty("value")]
    public string Value { get; set; }
}
