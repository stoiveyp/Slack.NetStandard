namespace Slack.NetStandard.Objects.WorkObjects.Fields;

public class BooleanField : EntityPayloadField
{
    public const string TypeName = "boolean";
    public override string Type => TypeName;
    public BooleanField(bool value) { Value = value; }
    public bool Value { get; set; }
}
