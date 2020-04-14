using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Conversations;

namespace Slack.NetStandard.WebApi
{
    internal class AdminApi:IAdminApi
    {
        private readonly IWebApiClient _client;

        public IAdminAppsApi Apps { get; }
        public IAdminConversationsApi Conversations { get; }

        internal AdminApi(IWebApiClient client)
        {
            _client = client;
            Apps = new AdminAppsApi(client);
            Conversations = new AdminConversationsApi(client);
        }
        public Task<WebApiResponse> Archive(string channel)
        {
            return _client.MakeJsonCall<ChannelRequest, WebApiResponse>("conversations.archive", new ChannelRequest
            {
                Channel = channel
            });
        }
    }
}
