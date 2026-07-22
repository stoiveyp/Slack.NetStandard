namespace Slack.NetStandard.Objects.Workflows.FormElements;

public class UserIdFormElement : TypedFormElement<string>
{
    public UserIdFormElement()
    {
        Type = WorkflowTypes.SlackTypes.UserId;
    }
}