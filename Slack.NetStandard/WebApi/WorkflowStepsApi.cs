using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Functions;

namespace Slack.NetStandard.WebApi;

internal class WorkflowStepsApi : IWorkflowStepsApi
{
    private readonly IWebApiClient _client;

    public WorkflowStepsApi(IWebApiClient client)
    {
        _client = client;
    }

    public Task<ListWorkflowStepResponse> List(ListWorkflowStepRequest request)
    {
        return _client.MakeJsonCall<ListWorkflowStepRequest, ListWorkflowStepResponse>("functions.workflows.steps.list", request);
    }

    public Task<WebApiResponse> ExportResponses(ExportResponseWorkflowStepRequest request)
    {
        return _client.MakeJsonCall("functions.workflows.steps.responses.export", request);
    }
}