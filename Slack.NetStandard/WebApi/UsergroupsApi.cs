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
        }

        public Task<UsergroupResponse> Create(UsergroupCreateRequest request)
        {
            return _client.MakeJsonCall<UsergroupCreateRequest, UsergroupResponse>("usergroups.create", request);
        }
    }
}