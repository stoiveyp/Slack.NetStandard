namespace Slack.NetStandard.Objects.Workflows.FormElements;

public class ChannelIdFormElement : TypedFormElement<string>
{
    public ChannelIdFormElement()
    {
        Type = WorkflowTypes.SlackTypes.ChannelId;
    }
}