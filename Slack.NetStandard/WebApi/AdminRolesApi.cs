using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi;

public class AdminRolesApi : IAdminRolesApi
{
    private readonly IWebApiClient _client;
    public AdminRolesApi(IWebApiClient client)
    {
        _client = client;
    }

    public Task<ModifyRoleAssignmentResponse> AddAssignments(ModifyRoleAssignmentRequest request)
    {
        return _client.MakeJsonCall<ModifyRoleAssignmentRequest,ModifyRoleAssignmentResponse>("admin.roles.addAssignments", request);
    }

    public Task<ListRoleAssignmentResponse> ListAssignments(ListRoleAssignmentRequest request)
    {
        return _client.MakeJsonCall<ListRoleAssignmentRequest, ListRoleAssignmentResponse>("admin.roles.listAssignments", request);
    }

    public Task<ModifyRoleAssignmentResponse> RemoveAssignments(ModifyRoleAssignmentRequest request)
    {
        return _client.MakeJsonCall<ModifyRoleAssignmentRequest,ModifyRoleAssignmentResponse>("admin.roles.removeAssignments", request);
    }
}