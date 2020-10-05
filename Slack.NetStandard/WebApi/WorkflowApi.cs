using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Workflow;

namespace Slack.NetStandard.WebApi
{
    internal class WorkflowApi : IWorkflowApi
    {
        private readonly IWebApiClient _client;

        public WorkflowApi(IWebApiClient client)
        {
            _client = client;
        }

        public Task<WebApiResponse> StepCompleted(string workflowStepExecuteId, Dictionary<string, string> outputs = null)
        {
            return _client.MakeJsonCall("workflows.stepCompleted", new StepCompletedRequest { WorkflowStepExecuteId = workflowStepExecuteId, Outputs = outputs});
        }
    }
}