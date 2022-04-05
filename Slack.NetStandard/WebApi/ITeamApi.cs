using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Teams;

namespace Slack.NetStandard.WebApi
{
    public interface ITeamApi
    {
        Task<TeamAccessLogResponse> AccessLogs(long before);
        Task<TeamAccessLogResponse> AccessLogs(int count, int page);
        Task<TeamAccessLogResponse> AccessLogs(long? before, int? count, int? page);

        Task<BillableInfoResponse> BillableInfo(string user = null);
        Task<InfoResponse> Info(string team = null, string domain = null);
        Task<TeamIntegrationLogResponse> IntegrationLogs(IntegrationLogRequest request);

        Task<TeamProfileResponse> GetProfile(string visibility);

        ITeamBillingApi Billing { get; }
    }
}
