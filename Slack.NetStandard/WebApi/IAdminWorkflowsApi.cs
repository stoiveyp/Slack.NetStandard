using Slack.NetStandard.WebApi.Admin;
using System.Threading.Tasks;

namespace Slack.NetStandard.WebApi;

public interface IAdminWorkflowsApi
{
    Task<WorkflowSearchResponse> Search(WorkflowSearchRequest request);
}