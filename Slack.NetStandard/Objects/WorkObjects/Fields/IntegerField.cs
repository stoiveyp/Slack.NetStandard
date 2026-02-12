namespace Slack.NetStandard.Objects.WorkObjects.Fields;

public class IntegerField : EntityPayloadField
{
    public const string TypeName = "integer";
    public override string Type => TypeName;
    public IntegerField(int value) { Value = value; }
    public int Value { get; set; }
}
