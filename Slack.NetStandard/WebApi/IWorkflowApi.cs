using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.WebApi
{
    public interface IWorkflowApi
    {
        [Obsolete("Steps from apps are now deprecated. For more information see https://api.slack.com/changelog/2023-08-workflow-steps-from-apps-step-back")]
        Task<WebApiResponse> StepCompleted(string workflowStepExecuteId, Dictionary<string, object> outputs = null);
        [Obsolete("Steps from apps are now deprecated. For more information see https://api.slack.com/changelog/2023-08-workflow-steps-from-apps-step-back")]
        Task<WebApiResponse> StepFailed(string workflowStepExecuteId, string errorMessage);
        [Obsolete("Steps from apps are now deprecated. For more information see https://api.slack.com/changelog/2023-08-workflow-steps-from-apps-step-back")]
        Task<WebApiResponse> UpdateStep(WorkflowStep step);
    }
}
