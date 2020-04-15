using System;
using System.Threading.Tasks;

namespace Slack.NetStandard.WebApi
{
    internal class AdminTeamSettingsApi : IAdminTeamSettingsApi
    {
        private readonly IWebApiClient _client;
        public AdminTeamSettingsApi(IWebApiClient client)
        {
            _client = client;
        }

        public Task Info()
        {
            throw new NotImplementedException();
        }

        public Task SetDefaultChannels()
        {
            throw new NotImplementedException();
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