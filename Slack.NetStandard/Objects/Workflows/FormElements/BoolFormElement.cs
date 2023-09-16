namespace Slack.NetStandard.Objects.Workflows.FormElements;

public class BoolFormElement : StructFormElement<bool>
{
    public BoolFormElement()
    {
        Type = WorkflowTypes.BuiltInTypes.Boolean;
    }

    public DateFormElement()
    {
        Type = WorkflowTypes.SlackTypes.Date;
    }
}