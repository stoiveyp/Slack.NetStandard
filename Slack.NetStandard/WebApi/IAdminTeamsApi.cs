using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi
{
    public interface IAdminTeamsApi
    {
        Task<ListTeamsResponse> List(string cursor = null);
        Task<ListTeamsResponse> List(int limit);
        Task<ListTeamsResponse> List(string cursor, int? limit);
        Task<ListAdminsResponse> ListAdmins(string teamId);
        Task<ListAdminsResponse> ListAdmins(string teamId, string cursor);
        Task<ListAdminsResponse> ListAdmins(string teamId, int limit);
        Task<ListAdminsResponse> ListAdmins(string teamId, string cursor, int? limit);

        Task<ListOwnersResponse> ListOwners(string teamId);
        Task<ListOwnersResponse> ListOwners(string teamId, string cursor);
        Task<ListOwnersResponse> ListOwners(string teamId, int limit);
        Task<ListOwnersResponse> ListOwners(string teamId, string cursor, int? limit);

        Task<TeamCreateResponse> Create(TeamCreateRequest request);

        IAdminTeamSettingsApi Settings { get; }
    }
}