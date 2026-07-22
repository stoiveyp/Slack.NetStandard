using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Functions;

namespace Slack.NetStandard.WebApi;

public interface IWorkflowStepsApi
{
    Task<ListWorkflowStepResponse> List(ListWorkflowStepRequest request);
    Task<WebApiResponse> ExportResponses(ExportResponseWorkflowStepRequest request);
}