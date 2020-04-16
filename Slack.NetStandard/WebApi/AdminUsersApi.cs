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

        public Task Invite()
        {
            throw new NotImplementedException();
        }

        public Task List()
        {
            throw new NotImplementedException();
        }

        public Task Remove()
        {
            throw new NotImplementedException();
        }

        public Task SetAdmin()
        {
            throw new NotImplementedException();
        }

        public Task SetExpiration()
        {
            throw new NotImplementedException();
        }

        public Task SetOwner()
        {
            throw new NotImplementedException();
        }

        public Task SetRegular()
        {
            throw new NotImplementedException();
        }

        public Task ResetSession()
        {
            throw new NotImplementedException();
        }
    }
}
