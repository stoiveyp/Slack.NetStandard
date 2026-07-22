namespace Slack.NetStandard.Objects.Workflows.FormElements;

public class RichTextFormElement : FormElement
{
    public RichTextFormElement()
    {
        Type = WorkflowTypes.SlackTypes.RichText;
    }
}