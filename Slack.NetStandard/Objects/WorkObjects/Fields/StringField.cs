namespace Slack.NetStandard.Objects.WorkObjects.Fields;

public class StringField : EntityPayloadField
{
    public const string TypeName = "string";

    public override string Type => TypeName;
    public StringField(string value) { Value = value; }
    public string Value { get; set; }
}
