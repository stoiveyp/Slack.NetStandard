using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Usergroups;

namespace Slack.NetStandard.WebApi
{
    internal class UsergroupsApi : IUsergroupsApi
    {
        private readonly IWebApiClient _client;

        public UsergroupsApi(IWebApiClient client)
        {
            _client = client;
            Users = new UsergroupsUserApi(client);
        }

        public IUsergroupUserApi Users { get; }

        public Task<UsergroupResponse> Create(UsergroupCreateRequest request)
        {
            return _client.MakeJsonCall<UsergroupCreateRequest, UsergroupResponse>("usergroups.create", request);
        }

        public Task<UsergroupResponse> Disable(UsergroupDisableRequest request)
        {
            return _client.MakeUrlEncodedCall<UsergroupResponse>("usergroups.disable", request);
        }

        public Task<UsergroupResponse> Enable(UsergroupEnableRequest request)
        {
            return _client.MakeUrlEncodedCall<UsergroupResponse>("usergroups.enable", request);
        }

        public Task<UsergroupResponse> Update(UsergroupUpdateRequest request)
        {
            return _client.MakeJsonCall<UsergroupUpdateRequest, UsergroupResponse>("usergroups.update", request);
        }

        public Task<UsergroupListResponse> List(UsergroupListRequest request)
        {
            return _client.MakeUrlEncodedCall<UsergroupListResponse>("usergroups.list", request);
        }
    }
}