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

        public Task<WebApiResponse> SetDescription(string teamId, string description)
        {
            return _client.MakeUrlEncodedCall("admin.teams.settings.setDescription",
                new Dictionary<string, string>
                {
                    {"team_id", teamId},
                    {"description",description }
                });
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