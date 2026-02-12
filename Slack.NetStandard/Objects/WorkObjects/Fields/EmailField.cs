using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.WorkObjects.Fields;

public class EmailField : EntityPayloadField
{
    public const string TypeName = "slack#/types/email";

    [JsonProperty("type")]
    public override string Type => TypeName;

    [JsonProperty("value")]
    public string Value { get; set; }
}