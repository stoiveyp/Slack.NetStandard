using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.NetStandard.Objects;
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

        [Obsolete("Steps from apps are now deprecated. For more information see https://api.slack.com/changelog/2023-08-workflow-steps-from-apps-step-back")]
        public Task<WebApiResponse> StepCompleted(string workflowStepExecuteId, Dictionary<string, object> outputs = null)
        {
            return _client.MakeJsonCall("workflows.stepCompleted", new StepCompletedRequest { WorkflowStepExecuteId = workflowStepExecuteId, Outputs = outputs });
        }

        [Obsolete("Steps from apps are now deprecated. For more information see https://api.slack.com/changelog/2023-08-workflow-steps-from-apps-step-back")]
        public Task<WebApiResponse> StepFailed(string workflowStepExecuteId, string errorMessage)
        {
            return _client.MakeJsonCall("workflows.stepFailed", new StepFailedRequest { WorkflowStepExecuteId = workflowStepExecuteId, Error = new Error { Message = errorMessage } });
        }

        [Obsolete("Steps from apps are now deprecated. For more information see https://api.slack.com/changelog/2023-08-workflow-steps-from-apps-step-back")]
        public Task<WebApiResponse> UpdateStep(WorkflowStep step)
        {
            return _client.MakeJsonCall("workflows.updateStep", step);
        }
    }
}