using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Conversations;

namespace Slack.NetStandard.WebApi
{
    public class ConversationsApi : IConversationsApi
    {
        private readonly IWebApiClient _client;
        internal ConversationsApi(IWebApiClient client)
        {
            _client = client;
        }
        public Task<WebApiResponse> Archive(string channel)
        {
            return _client.MakeJsonCall<ChannelRequest, WebApiResponse>("conversations.archive", new ChannelRequest
            {
                Channel = channel
            });
        }

        public Task<CloseConversationResponse> Close(string channel)
        {
            return _client.MakeJsonCall<ChannelRequest, CloseConversationResponse>("conversations.close", new ChannelRequest
            {
                Channel = channel
            });
        }
    }
}
