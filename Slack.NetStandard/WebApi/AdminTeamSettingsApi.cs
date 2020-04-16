using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi
{
    internal class AdminTeamSettingsApi : IAdminTeamSettingsApi
    {
        private readonly IWebApiClient _client;
        public AdminTeamSettingsApi(IWebApiClient client)
        {
            _client = client;
        }

        public Task<TeamInfoResponse> Info(string teamId)
        {
            return _client.MakeUrlEncodedCall<TeamInfoResponse>("admin.teams.settings.info",
                new Dictionary<string, string>
                {
                    {"team_id", teamId}
                });
        }

        public Task<WebApiResponse> SetDefaultChannels(string teamId, params string[] defaultChannels)
        {
            return _client.MakeUrlEncodedCall("admin.teams.settings.setDefaultChannels",
                new Dictionary<string, string>
                {
                    {"team_id", teamId},
                    {"channel_ids",string.Join(",",defaultChannels) }
                });
        }

        public Task SetDescription()
        {
            throw new NotImplementedException();
        }

        public Task SetDiscoverability()
        {
            throw new NotImplementedException();
        }

        public Task SetIcon()
        {
            throw new NotImplementedException();
        }

        public Task SetName()
        {
            throw new NotImplementedException();
        }
    }
}