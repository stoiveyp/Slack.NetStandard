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

        Task ListOwners();
        Task<TeamCreateResponse> Create(TeamCreateRequest request);

        IAdminTeamSettingsApi Settings { get; }
    }
}