using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi
{
    internal class AdminUsersApi : IAdminUsersApi
    {
        private readonly IWebApiClient _client;
        public AdminUsersApi(IWebApiClient client)
        {
            _client = client;
            Session = new AdminUserSessionApi(client);
        }

        public IAdminUserSessionApi Session { get; }

        public Task<WebApiResponse> Assign(AssignUserRequest request)
        {
            return _client.MakeJsonCall("admin.users.assign", request);
        }

        public Task<WebApiResponse> Invite(InviteUserRequest request)
        {
            return _client.MakeJsonCall("admin.users.invite", request);
        }

        public Task<ListUsersResponse> List(string teamId)
        {
            return List(teamId, null, null);
        }

        public Task<ListUsersResponse> List(string teamId, string cursor)
        {
            return List(teamId, cursor, null);
        }

        public Task<ListUsersResponse> List(string teamId, int limit)
        {
            return List(teamId, null, limit);
        }

        public Task<ListUsersResponse> List(string teamId, string cursor, int? limit)
        {
            return _client.MakeJsonCall<CursorLimit, ListUsersResponse>("admin.users.list",
                new TeamRequestFilter { Team = teamId, Cursor = cursor, Limit = limit });
        }

        public Task<WebApiResponse> Remove(string teamId, string userId)
        {
            return _client.MakeJsonCall("admin.users.remove", new TeamUserRequest
            {
                TeamId = teamId,
                UserId = userId
            });
        }

        public Task<WebApiResponse> SetAdmin(string teamId, string userId)
        {
            return _client.MakeJsonCall("admin.users.setAdmin", new TeamUserRequest
            {
                TeamId = teamId,
                UserId = userId
            });
        }

        public Task<WebApiResponse> SetExpiration(string teamId, string userId, long expirationTimestamp)
        {
            return _client.MakeJsonCall("admin.users.setExpiration", new SetExpirationRequest
            {
                TeamId = teamId,
                UserId = userId,
                ExpirationTimestamp = expirationTimestamp
            });
        }

        public Task<WebApiResponse> SetOwner(string teamId, string userId)
        {
            return _client.MakeJsonCall("admin.users.setOwner", new TeamUserRequest
            {
                TeamId = teamId,
                UserId = userId
            });
        }

        public Task<WebApiResponse> SetRegular(string teamId, string userId)
        {
            return _client.MakeJsonCall("admin.users.setRegular", new TeamUserRequest
            {
                TeamId = teamId,
                UserId = userId
            });
        }

        public Task<WebApiResponse> UnsupportedVersions(DateTime? endOfSupport = null, DateTime? sessionStart = null)
        {
            var dict = new Dictionary<string, string> ();

            if (endOfSupport.HasValue)
            {
                dict.Add("date_end_of_support", Epoch.For(endOfSupport.Value).ToString());
            }

            if (sessionStart.HasValue)
            {
                dict.Add("date_sessions_started", Epoch.For(sessionStart.Value).ToString());
            }

            return _client.MakeUrlEncodedCall("admin.users.unsupportedVersions.export", dict);
        }
    }
}
