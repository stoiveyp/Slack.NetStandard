namespace Slack.NetStandard.Objects.Workflows.FormElements;

public class OAuth2FormElement : FormElement
{
    public OAuth2FormElement()
    {
        Type = WorkflowTypes.SlackTypes.OAuth2;
    }
}