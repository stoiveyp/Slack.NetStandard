using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.WebApi
{
    internal class AdminConversationsApi : IAdminConversationsApi
    {
        private readonly IWebApiClient _client;
        public AdminConversationsApi(IWebApiClient client)
        {
            _client = client;
        }
        public Task<WebApiResponse> SetTeams(SetTeamsRequest request)
        {
            return _client.MakeJsonCall<SetTeamsRequest, WebApiResponse>("admin.conversations.setTeams", request);
        }
    }
}