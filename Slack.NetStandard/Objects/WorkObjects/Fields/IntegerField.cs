using Newtonsoft.Json;
using System.Diagnostics.Contracts;

namespace Slack.NetStandard.Objects.WorkObjects.Fields;

public class IntegerField : EntityPayloadField
{
    public const string TypeName = "integer";
    public override string Type => TypeName;

    public IntegerField() { }
    public IntegerField(int value) { Value = value; }
    [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
    public int? Value { get; set; }
}
