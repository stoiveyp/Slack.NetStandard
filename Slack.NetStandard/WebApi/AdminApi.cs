using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Conversations;

namespace Slack.NetStandard.WebApi
{
    internal class AdminApi:IAdminApi
    {
        private readonly IWebApiClient _client;

        public IAdminAppsApi Apps { get; }

        internal AdminApi(IWebApiClient client)
        {
            _client = client;
            Apps = new AdminAppsApi(client);
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
