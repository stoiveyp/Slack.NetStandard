using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi
{
    internal class AdminAppsApi:IAdminAppsApi
    {
        private readonly IWebApiClient _client;
        public AdminAppsApi(IWebApiClient client)
        {
            _client = client;
        }

        public Task<WebApiResponse> ApproveApp(string appId, string teamId = null)
        {
            return _client.MakeJsonCall("admin.apps.approve", new AdminAppDecision
            {
                AppId = appId,
                TeamId = teamId
            });
        }

        public Task<WebApiResponse> ApproveRequest(string requestId, string teamId = null)
        {
            return _client.MakeJsonCall("admin.apps.approve", new AdminAppDecision
            {
                RequestId = requestId,
                TeamId = teamId
            });
        }

        public Task<WebApiResponse> RestrictApp(string appId, string teamId = null)
        {
            return _client.MakeJsonCall("admin.apps.restrict", new AdminAppDecision
            {
                AppId = appId,
                TeamId = teamId
            });
        }

        public Task<WebApiResponse> RestrictRequest(string requestId, string teamId = null)
        {
            return _client.MakeJsonCall("admin.apps.restrict", new AdminAppDecision
            {
                RequestId = requestId,
                TeamId = teamId
            });
        }

        public Task<ListAppRequestResponse> ListAppRequests(TeamRequestFilter filters)
        {
            return _client.MakeJsonCall<TeamRequestFilter, ListAppRequestResponse>("admin.apps.requests.list", filters);
        }

        public Task<ListApprovedAppResponse> ListApprovedApps(TeamFilter filters)
        {
            return _client.MakeJsonCall<TeamFilter, ListApprovedAppResponse>("admin.apps.approved.list", filters);
        }

        public Task<ListRestrictedAppResponse> ListRestrictedApps(TeamFilter filters)
        {
            return _client.MakeJsonCall<TeamFilter, ListRestrictedAppResponse>("admin.apps.restricted.list", filters);
        }
    }
}
