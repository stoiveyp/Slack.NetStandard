namespace Slack.NetStandard.Objects.Workflows.FormElements;

public class UsergroupFormElement : TypedFormElement<string>
{
    public UsergroupFormElement()
    {
        Type = WorkflowTypes.SlackTypes.UsergroupId;
    }
}