using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi
{
    internal class AdminTeamsApi:IAdminTeamsApi
    {
        private readonly IWebApiClient _client;
        public AdminTeamsApi(IWebApiClient client)
        {
            _client = client;
            Settings = new AdminTeamSettingsApi(client);
        }

        public Task<ListTeamsResponse> List(string cursor = null)
        {
            return List(cursor, null);
        }

        public Task<ListTeamsResponse> List(int limit)
        {
            return List(null, limit);
        }

        public Task<ListTeamsResponse> List(string cursor, int? limit)
        {
            return _client.MakeJsonCall<CursorLimit, ListTeamsResponse>("admin.teams.list",
                new CursorLimit {Cursor = cursor, Limit = limit});
        }

        public Task<ListAdminsResponse> ListAdmins(string teamId)
        {
            return ListAdmins(teamId,null,null);
        }

        public Task<ListAdminsResponse> ListAdmins(string teamId, string cursor)
        {
            return ListAdmins(teamId, cursor, null);
        }

        public Task<ListAdminsResponse> ListAdmins(string teamId, int limit)
        {
            return ListAdmins(teamId, null, limit);
        }

        public Task<ListAdminsResponse> ListAdmins(string teamId, string cursor, int? limit)
        {
            var dict =new Dictionary<string,string>
            {
                {"team_id",teamId}
            }.AddPaging(cursor,limit);

            return _client.MakeUrlEncodedCall<ListAdminsResponse>("admin.teams.admins.list",dict);
        }

        public Task<ListOwnersResponse> ListOwners(string teamId)
        {
            return ListOwners(teamId, null, null);
        }

        public Task<ListOwnersResponse> ListOwners(string teamId, string cursor)
        {
            return ListOwners(teamId, cursor, null);
        }

        public Task<ListOwnersResponse> ListOwners(string teamId, int limit)
        {
            return ListOwners(teamId, null, limit);
        }

        public Task<ListOwnersResponse> ListOwners(string teamId, string cursor, int? limit)
        {
            var dict = new Dictionary<string, string>
            {
                {"team_id",teamId}
            };
            if (!string.IsNullOrWhiteSpace(cursor))
            {
                dict.Add("cursor", cursor);
            }

            if (limit.HasValue)
            {
                dict.Add("limit", limit.Value.ToString());
            }

            return _client.MakeUrlEncodedCall<ListOwnersResponse>("admin.teams.owners.list", dict);
        }

        public Task<TeamCreateResponse> Create(TeamCreateRequest request)
        {
            return _client.MakeJsonCall<TeamCreateRequest,TeamCreateResponse>("admin.teams.create", request);
        }

        public IAdminTeamSettingsApi Settings { get; }
    }
}
