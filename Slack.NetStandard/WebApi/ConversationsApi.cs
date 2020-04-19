using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Conversations;

namespace Slack.NetStandard.WebApi
{
    internal class ConversationsApi : IConversationsApi
    {
        private readonly IWebApiClient _client;
        internal ConversationsApi(IWebApiClient client)
        {
            _client = client;
        }
        public Task<WebApiResponse> Archive(string channel)
        {
            return _client.MakeJsonCall("conversations.archive", new ChannelRequest
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

        public Task<ChannelResponse> Create(string name, bool isPrivate = false)
        {
            return _client.MakeJsonCall<CreateConversationRequest, ChannelResponse>("conversations.create",
                new CreateConversationRequest
                {
                    Name = name,
                    IsPrivate = isPrivate
                });
        }

        public Task<ChannelResponse> Create(string name, string[] userIds, bool isPrivate = false)
        {
            return _client.MakeJsonCall<CreateConversationRequest, ChannelResponse>("conversations.create",
                new CreateConversationRequest
                {
                    Name = name,
                    IsPrivate = isPrivate,
                    UserIds = userIds
                });
        }

        public Task<ConversationHistoryResponse> History(ConversationHistoryRequest request)
        {
            return _client.MakeJsonCall<ConversationHistoryRequest, ConversationHistoryResponse>(
                "conversations.history", request);
        }

        public Task<ChannelResponse> Info(string channel, bool? includeLocale, bool? includeNumberOfMembers)
        {
            var dict = new Dictionary<string, string> {{"channel", channel}};
            if (includeLocale.HasValue)
            {
                dict.Add("include_locale",includeLocale.Value.ToString().ToLower());
            }

            if (includeNumberOfMembers.HasValue)
            {
                dict.Add("include_num_members", includeNumberOfMembers.Value.ToString().ToLower());
            }
            return _client.MakeUrlEncodedCall<ChannelResponse>(
                "conversations.info", dict);
        }
    }
}
