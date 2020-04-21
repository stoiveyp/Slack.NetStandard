using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi
{
    internal class AdminInviteRequestsApi:IAdminInviteRequestsApi
    {
        private readonly IWebApiClient _client;
        public AdminInviteRequestsApi(IWebApiClient client)
        {
            _client = client;
        }

        public Task<WebApiResponse> Approve(string inviteRequestId, string teamId = null)
        {
            return _client.MakeJsonCall("admin.inviteRequests.approve", new AdminInviteRequestDecision
            {
                InviteRequestId = inviteRequestId,
                TeamId = teamId
            });
        }

        public Task<WebApiResponse> Deny(string inviteRequestId, string teamId = null)
        {
            return _client.MakeJsonCall("admin.inviteRequests.deny", new AdminInviteRequestDecision
            {
                InviteRequestId = inviteRequestId,
                TeamId = teamId
            });
        }

        public Task<ListInviteRequestResponse> ListInviteRequests(TeamRequestFilter filters)
        {
            return _client.MakeJsonCall<TeamRequestFilter,ListInviteRequestResponse>("admin.inviteRequests.list", filters);
        }

        public Task<ListApprovedInviteRequestResponse> ListApprovedInviteRequests(TeamRequestFilter filters)
        {
            return _client.MakeJsonCall<TeamRequestFilter, ListApprovedInviteRequestResponse>("admin.inviteRequests.approved.list", filters);
        }

        public Task<ListDeniedInviteRequestResponse> ListDeniedInviteRequests(TeamRequestFilter filters)
        {
            return _client.MakeJsonCall<TeamRequestFilter, ListDeniedInviteRequestResponse>("admin.inviteRequests.denied.list", filters);
        }
    }
}
