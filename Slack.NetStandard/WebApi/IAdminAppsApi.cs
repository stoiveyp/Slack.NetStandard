using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi
{
    public interface IAdminAppsApi
    {
        Task<WebApiResponse> ApproveApp(string appId, string teamId = null);
        Task<WebApiResponse> ApproveRequest(string requestId, string teamId = null);
        Task<WebApiResponse> RestrictApp(string appId, string teamId = null);
        Task<WebApiResponse> RestrictRequest(string requestId, string teamId = null);

        Task<ListAppRequestResponse> ListAppRequests(AppRequestFilter filters);
        Task<ListApprovedAppResponse> ListApprovedApps(AppFilter filters);
        Task<ListRestrictedAppResponse> ListRestrictedApps(AppFilter filters);
    }

    public interface IAdminConversationsApi
    {
        Task<WebApiResponse> SetTeams(SetTeamsRequest request);
    }
}
