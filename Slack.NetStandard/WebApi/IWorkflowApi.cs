using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.WebApi
{
    public interface IWorkflowApi
    {
        Task<WebApiResponse> StepCompleted(string workflowStepExecuteId, Dictionary<string, object> outputs = null);
        Task<WebApiResponse> StepFailed(string workflowStepExecuteId, string errorMessage);
        Task<WebApiResponse> UpdateStep(WorkflowStep step);
    }
}
