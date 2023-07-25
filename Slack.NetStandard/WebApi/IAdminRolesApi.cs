using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi;

public interface IAdminRolesApi
{
    Task<ModifyRoleAssignmentResponse> AddAssignments(ModifyRoleAssignmentRequest request);
    Task<ListRoleAssignmentResponse> ListAssignments(ListRoleAssignmentRequest request);
    Task<ModifyRoleAssignmentResponse> RemoveAssignments(ModifyRoleAssignmentRequest request);
}