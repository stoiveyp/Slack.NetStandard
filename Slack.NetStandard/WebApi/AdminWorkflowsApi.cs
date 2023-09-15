using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi;

internal class AdminWorkflowsApi : IAdminWorkflowsApi
{
    private readonly IWebApiClient _client;
    public AdminWorkflowsApi(IWebApiClient client)
    {
        _client = client;
    }

    public Task<WorkflowSearchResponse> Search(WorkflowSearchRequest request)
    {
        return _client.MakeJsonCall<WorkflowSearchRequest, WorkflowSearchResponse>("admin.workflows.search", request);
    }
}