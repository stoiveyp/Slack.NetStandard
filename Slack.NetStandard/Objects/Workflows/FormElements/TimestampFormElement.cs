namespace Slack.NetStandard.Objects.Workflows.FormElements;

public class TimestampFormElement : TypedFormElement<string>
{
    public TimestampFormElement()
    {
        Type = WorkflowTypes.SlackTypes.Timestamp;
    }
}