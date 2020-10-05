using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Slack.NetStandard.WebApi
{
    public interface IWorkflowApi
    {
        Task<WebApiResponse> StepCompleted(string workflowStepExecuteId, Dictionary<string, string> outputs = null);
    }
}
