using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Teams;

namespace Slack.NetStandard.WebApi
{
    public interface ITeamApi
    {
        Task<TeamAccessLogResponse> AccessLogs(long before, string teamId = null);
        Task<TeamAccessLogResponse> AccessLogs(int count, int page, string teamId = null);
        Task<TeamAccessLogResponse> AccessLogs(long? before, int? count, int? page, string teamId = null);

        Task<BillableInfoResponse> BillableInfo(string user = null, string teamId = null);
        Task<InfoResponse> Info(string team = null, string domain = null);
        Task<TeamIntegrationLogResponse> IntegrationLogs(IntegrationLogRequest request);

        Task<TeamProfileResponse> GetProfile(string visibility, string teamId = null);
        Task<PreferenceListResponse> GetPreferences();

        ITeamBillingApi Billing { get; }
    }
}