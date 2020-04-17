using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi
{
    public interface IAdminUsersApi
    {
        Task<WebApiResponse> Assign(AssignUserRequest request);
        Task<WebApiResponse> Invite(InviteUserRequest request);

        Task<ListUsersResponse> List(string teamId);
        Task<ListUsersResponse> List(string teamId, string cursor);
        Task<ListUsersResponse> List(string teamId, int limit);
        Task<ListUsersResponse> List(string teamId, string cursor, int? limit);

        Task<WebApiResponse> Remove(string teamId, string userId);
        Task<WebApiResponse> SetAdmin(string teamId, string userId);
        Task SetExpiration();
        Task<WebApiResponse> SetOwner(string teamId, string userId);
        Task<WebApiResponse> SetRegular(string teamId, string userId);

        Task ResetSession();
    }
}
