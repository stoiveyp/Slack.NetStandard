namespace Slack.NetStandard.Objects.Workflows.FormElements;

public class DateFormElement : TypedFormElement<string>
{
    public DateFormElement()
    {
        Type = WorkflowTypes.SlackTypes.Date;
    }
}