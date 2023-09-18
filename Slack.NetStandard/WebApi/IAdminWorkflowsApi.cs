using System.Collections.Generic;
using Slack.NetStandard.WebApi.Admin;
using System.Threading.Tasks;

namespace Slack.NetStandard.WebApi;

public interface IAdminWorkflowsApi
{
    Task<WorkflowSearchResponse> Search(WorkflowSearchRequest request);
    Task<WorkflowPermissionLookupResponse> LookupPermissions(IEnumerable<string> workflowIds, int? maxWorkflowTriggers = null);
    Task<WebApiResponse> Unpublish(IEnumerable<string> workflowIds);
    Task<WebApiResponse> AddCollaborators(IEnumerable<string> collaboratorIds, IEnumerable<string> workflowIds);
    Task<WebApiResponse> RemoveCollaborators(IEnumerable<string> collaboratorIds, IEnumerable<string> workflowIds);
}