namespace Slack.NetStandard.WebApi
{
    internal class WorkflowsApi : IWorkflowsApi
    {
        public WorkflowsApi(IWebApiClient client)
        {
            Featured = new WorkflowsFeaturedApi(client);
        }
        public IWorkflowsFeaturedApi Featured { get; }
    }
}