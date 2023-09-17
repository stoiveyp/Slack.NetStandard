using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
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

    public Task<PermissionLookupResponse> LookupPermissions(IEnumerable<string> workflowIds, int? maxWorkflowTriggers = null)
    {
        var workflowPermissions = new JObject
        {
            { "workflow_ids", new JArray((workflowIds ?? new string[]{}).ToArray()) }
        };

        if (maxWorkflowTriggers.HasValue)
        {
            workflowPermissions.Add("max_workflow_triggers", maxWorkflowTriggers);
        }

        return _client.MakeJsonCall<JObject,PermissionLookupResponse>("admin.workflows.permissions.lookup", workflowPermissions);
    }

    public Task<WebApiResponse> Unpublish(IEnumerable<string> workflowIds)
    {
        var unpublishRequest = new JObject
        {
            { "workflow_ids", new JArray((workflowIds ?? new string[]{}).ToArray()) }
        };

        return _client.MakeJsonCall("admin.workflows.unpublish", unpublishRequest);
    }

    public Task<WebApiResponse> AddCollaborators(IEnumerable<string> collaboratorIds, IEnumerable<string> workflowIds)
    {
        var addRequest = new JObject
        {
            { "workflow_ids", new JArray((workflowIds ?? new string[]{}).ToArray()) },
            { "collaborator_ids", new JArray((collaboratorIds ?? new string[]{}).ToArray()) }
        };

        return _client.MakeJsonCall("admin.workflows.collaborators.add", addRequest);
    }

    public Task<WebApiResponse> RemoveCollaborators(IEnumerable<string> collaboratorIds, IEnumerable<string> workflowIds)
    {
        var removeRequest = new JObject
        {
            { "workflow_ids", new JArray((workflowIds ?? new string[]{}).ToArray()) },
            { "collaborator_ids", new JArray((collaboratorIds ?? new string[]{}).ToArray()) }
        };

        return _client.MakeJsonCall("admin.workflows.collaborators.remove", removeRequest);
    }
}