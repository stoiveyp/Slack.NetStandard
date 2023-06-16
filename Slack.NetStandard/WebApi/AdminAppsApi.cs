using System.Collections.Generic;
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

        public Task<WebApiResponse> ApproveApp(string appId, string teamId = null, string enterpriseId = null)
        {
            return _client.MakeJsonCall("admin.apps.approve", new AdminAppDecision
            {
                AppId = appId,
                TeamId = teamId,
                EnterpriseId = enterpriseId
            });
        }

        public Task<WebApiResponse> ApproveRequest(string requestId, string teamId = null, string enterpriseId = null)
        {
            return _client.MakeJsonCall("admin.apps.approve", new AdminAppDecision
            {
                RequestId = requestId,
                TeamId = teamId,
                EnterpriseId = enterpriseId
            });
        }

        public Task<WebApiResponse> RestrictApp(string appId, string teamId = null, string enterpriseId = null)
        {
            return _client.MakeJsonCall("admin.apps.restrict", new AdminAppDecision
            {
                AppId = appId,
                TeamId = teamId,
                EnterpriseId = enterpriseId
            });
        }

        public Task<WebApiResponse> RestrictRequest(string requestId, string teamId = null, string enterpriseId = null)
        {
            return _client.MakeJsonCall("admin.apps.restrict", new AdminAppDecision
            {
                RequestId = requestId,
                TeamId = teamId,
                EnterpriseId = enterpriseId
            });
        }

        public Task<WebApiResponse> CancelRequest(string requestId, string teamId = null, string enterpriseId = null)
        {
            return _client.MakeJsonCall("admin.apps.requests.cancel", new AdminAppDecision
            {
                RequestId = requestId,
                TeamId = teamId,
                EnterpriseId = enterpriseId
            });
        }

        public Task<WebApiResponse> ClearResolution(string appId, string teamId = null, string enterpriseId = null)
        {
            return _client.MakeJsonCall("admin.apps.clearResolution", new AdminAppDecision
            {
                AppId = appId,
                TeamId = teamId,
                EnterpriseId = enterpriseId
            });
        }

        public Task<WebApiResponse> UninstallApp(string appId, List<string> teamIds = null, string enterpriseId = null)
        {
            return _client.MakeJsonCall("admin.apps.uninstall", new AdminUninstallRequest
            {
                AppId = appId,
                TeamIds = teamIds,
                EnterpriseId = enterpriseId
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
