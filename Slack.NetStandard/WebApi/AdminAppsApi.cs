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
            return _client.MakeJsonCall("admin.apps.approve", new AdminAppApproveRequest
            {
                AppId = appId,
                TeamId = teamId
            });
        }

        public Task<WebApiResponse> ApproveRequest(string requestId, string teamId = null)
        {
            return _client.MakeJsonCall("admin.apps.approve", new AdminAppApproveRequest
            {
                RequestId = requestId,
                TeamId = teamId
            });
        }

        public Task<WebApiResponse> RestrictApp(string appId, string teamId = null)
        {
            return _client.MakeJsonCall("admin.apps.restrict", new AdminAppApproveRequest
            {
                AppId = appId,
                TeamId = teamId
            });
        }

        public Task<WebApiResponse> RestrictRequest(string requestId, string teamId = null)
        {
            return _client.MakeJsonCall("admin.apps.restrict", new AdminAppApproveRequest
            {
                RequestId = requestId,
                TeamId = teamId
            });
        }

        public Task<ListAppRequestResponse> ListAppRequests(AppRequestFilter filters)
        {
            return _client.MakeJsonCall<AppRequestFilter, ListAppRequestResponse>("admin.apps.requests.list", filters);
        }

        public Task<ListApprovedAppResponse> ListApprovedApps(AppFilter filters)
        {
            return _client.MakeJsonCall<AppFilter, ListApprovedAppResponse>("admin.apps.approved.list", filters);
        }

        public Task<ListRestrictedAppResponse> ListRestrictedApps(AppFilter filters)
        {
            return _client.MakeJsonCall<AppFilter, ListRestrictedAppResponse>("admin.apps.restricted.list", filters);
        }
    }
}
