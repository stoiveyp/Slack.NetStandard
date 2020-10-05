namespace Slack.NetStandard.WebApi
{
    internal class WorkflowApi : IWorkflowApi
    {
        private readonly IWebApiClient _client;

        public WorkflowApi(IWebApiClient client)
        {
            _client = client;
        }
    }
}