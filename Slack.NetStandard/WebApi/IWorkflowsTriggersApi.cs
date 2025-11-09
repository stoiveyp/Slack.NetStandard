namespace Slack.NetStandard.WebApi
{
    public interface IWorkflowsTriggersApi
    {
        IWorkflowsTriggersPermissionsApi Permissions { get; }
    }
}