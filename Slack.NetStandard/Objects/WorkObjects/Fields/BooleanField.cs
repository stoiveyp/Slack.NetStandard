using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.WorkObjects.Fields;

public class BooleanField : EntityPayloadField
{
    public const string TypeName = "boolean";
    public override string Type => TypeName;

    public BooleanField() { }
    public BooleanField(bool value) { Value = value; }
    [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Value { get; set; }

    [JsonProperty("boolean", NullValueHandling = NullValueHandling.Ignore)]
    public BooleanOptions Options { get; set; }

}
