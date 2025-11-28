namespace Slack.NetStandard.WebApi
{
    internal class WorkflowsApi : IWorkflowsApi
    {
        public WorkflowsApi(IWebApiClient client)
        {
            Featured = new WorkflowsFeaturedApi(client);
            Triggers = new WorkflowsTriggersApi(client);
        }
        public IWorkflowsFeaturedApi Featured { get; }

        public IWorkflowsTriggersApi Triggers { get; }
    }
}