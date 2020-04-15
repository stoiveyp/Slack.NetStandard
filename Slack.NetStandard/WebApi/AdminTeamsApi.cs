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

        public Task List()
        {
            throw new NotImplementedException();
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
            };
            if (!string.IsNullOrWhiteSpace(cursor))
            {
                dict.Add("cursor",cursor);
            }

            if (limit.HasValue)
            {
                dict.Add("limit",limit.Value.ToString());
            }

            return _client.MakeUrlEncodedCall<ListAdminsResponse>("admin.teams.admins.list",dict);
        }

        public Task ListOwners()
        {
            throw new NotImplementedException();
        }

        public Task<TeamCreateResponse> Create(TeamCreateRequest request)
        {
            return _client.MakeJsonCall<TeamCreateRequest,TeamCreateResponse>("admin.teams.create", request);
        }

        public IAdminTeamSettingsApi Settings { get; }
    }
}
