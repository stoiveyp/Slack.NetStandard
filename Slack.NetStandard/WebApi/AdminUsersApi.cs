using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi
{
    internal class AdminUsersApi:IAdminUsersApi
    {
        private readonly IWebApiClient _client;
        public AdminUsersApi(IWebApiClient client)
        {
            _client = client;
        }

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
            return _client.MakeJsonCall<CursorLimit,ListUsersResponse>("admin.users.list",
                new TeamRequestFilter {Team = teamId, Cursor = cursor, Limit = limit});
        }

        public Task<WebApiResponse> Remove(string teamId, string userId)
        {
            return _client.MakeUrlEncodedCall("admin.users.remove", new Dictionary<string, string>
            {
                {"team_id", teamId},
                {"user_id", userId}
            });
        }

        public Task<WebApiResponse> SetAdmin(string teamId, string userId)
        {
            return _client.MakeUrlEncodedCall("admin.users.setAdmin", new Dictionary<string, string>
            {
                {"team_id", teamId},
                {"user_id", userId}
            });
        }

        public Task SetExpiration()
        {
            throw new NotImplementedException();
        }

        public Task<WebApiResponse> SetOwner(string teamId, string userId)
        {
            return _client.MakeUrlEncodedCall("admin.users.setOwner", new Dictionary<string, string>
            {
                {"team_id", teamId},
                {"user_id", userId}
            });
        }

        public Task<WebApiResponse> SetRegular(string teamId, string userId)
        {
            return _client.MakeUrlEncodedCall("admin.users.setRegular", new Dictionary<string, string>
            {
                {"team_id", teamId},
                {"user_id", userId}
            });
        }

        public Task ResetSession()
        {
            throw new NotImplementedException();
        }
    }
}
