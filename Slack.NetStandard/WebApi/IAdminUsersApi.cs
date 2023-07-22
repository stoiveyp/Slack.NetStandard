using System;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi
{
    public interface IAdminUsersApi
    {
        IAdminUserSessionApi Session { get; }

        Task<WebApiResponse> Assign(AssignUserRequest request);
        Task<WebApiResponse> Invite(InviteUserRequest request);

        Task<ListUsersResponse> List(string teamId);
        Task<ListUsersResponse> List(string teamId, string cursor);
        Task<ListUsersResponse> List(string teamId, int limit);
        Task<ListUsersResponse> List(string teamId, string cursor, int? limit);

        Task<WebApiResponse> Remove(string teamId, string userId);
        Task<WebApiResponse> SetAdmin(string teamId, string userId);
        Task<WebApiResponse> SetExpiration(string teamId, string userId, long expirationTimestamp);
        Task<WebApiResponse> SetOwner(string teamId, string userId);
        Task<WebApiResponse> SetRegular(string teamId, string userId);

        Task<WebApiResponse> UnsupportedVersions(DateTime? endOfSupport = null, DateTime? sessionStart = null);
    }
}
