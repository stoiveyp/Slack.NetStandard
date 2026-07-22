namespace Slack.NetStandard.Objects.Workflows.FormElements;

public class MessageContextFormElement : FormElement
{
    public MessageContextFormElement()
    {
        Type = WorkflowTypes.SlackTypes.MessageContext;
    }
}