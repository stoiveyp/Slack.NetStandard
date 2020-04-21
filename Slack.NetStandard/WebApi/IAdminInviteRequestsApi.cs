using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi
{
    public interface IAdminInviteRequestsApi
    {
        Task<WebApiResponse> Approve(string inviteRequestId, string teamId = null);
        Task<WebApiResponse> Deny(string inviteRequestId, string teamId = null);
        Task<ListInviteRequestResponse> ListInviteRequests(TeamRequestFilter filters);
        Task<ListApprovedInviteRequestResponse> ListApprovedInviteRequests(TeamRequestFilter filters);
        Task<ListDeniedInviteRequestResponse> ListDeniedInviteRequests(TeamRequestFilter filters);
    }
}
