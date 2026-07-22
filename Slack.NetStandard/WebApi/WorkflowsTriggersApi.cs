namespace Slack.NetStandard.WebApi
{
    internal class WorkflowsTriggersApi : IWorkflowsTriggersApi
    {
        public WorkflowsTriggersApi(IWebApiClient client)
        {
            Permissions = new WorkflowsTriggersPermissionsApi(client);
        }

        public IWorkflowsTriggersPermissionsApi Permissions { get; }
    }
}