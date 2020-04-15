using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public Task ListAdmins()
        {
            throw new NotImplementedException();
        }

        public Task ListOwners()
        {
            throw new NotImplementedException();
        }

        public Task Create()
        {
            throw new NotImplementedException();
        }

        public IAdminTeamSettingsApi Settings { get; }
    }
}
