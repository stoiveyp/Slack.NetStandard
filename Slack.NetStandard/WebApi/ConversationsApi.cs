using System.Collections.Generic;
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
            return _client.MakeUrlEncodedCall<ConversationHistoryResponse>(
                "conversations.history", request);
        }

        public Task<ChannelResponse> Info(string channel, bool? includeLocale, bool? includeNumberOfMembers)
        {
            var dict = new Dictionary<string, string> { { "channel", channel } };
            if (includeLocale.HasValue)
            {
                dict.Add("include_locale", includeLocale.Value.ToString().ToLower());
            }

            if (includeNumberOfMembers.HasValue)
            {
                dict.Add("include_num_members", includeNumberOfMembers.Value.ToString().ToLower());
            }
            return _client.MakeUrlEncodedCall<ChannelResponse>(
                "conversations.info", dict);
        }

        public Task<ChannelResponse> Invite(string channel, params string[] users)
        {
            var dict = new Dictionary<string, string>
            {
                { "channel", channel },
                {"users",string.Join(",",users) }
            };

            return _client.MakeUrlEncodedCall<ChannelResponse>(
                "conversations.invite", dict);
        }

        public Task<ChannelResponse> Join(string channel)
        {
            var dict = new Dictionary<string, string>
            {
                { "channel", channel }
            };

            return _client.MakeUrlEncodedCall<ChannelResponse>(
                "conversations.join", dict);
        }

        public Task<WebApiResponse> Kick(string channel, string user)
        {
            var dict = new Dictionary<string, string>
            {
                { "channel", channel },
                {"user",user}
            };

            return _client.MakeUrlEncodedCall(
                "conversations.kick", dict);
        }

        public Task<WebApiResponse> Leave(string channel)
        {
            var dict = new Dictionary<string, string>
            {
                { "channel", channel }
            };

            return _client.MakeUrlEncodedCall(
                "conversations.leave", dict);
        }

        public Task<ChannelListResponse> List(ConversationListRequest request)
        {
            return _client.MakeUrlEncodedCall<ChannelListResponse>("conversations.list", request);
        }

        public Task<ConversationMembersResponse> Members(string channel)
        {
            return Members(channel, null, null);
        }

        public Task<ConversationMembersResponse> Members(string channel, string cursor)
        {
            return Members(channel, cursor, null);
        }

        public Task<ConversationMembersResponse> Members(string channel, int limit)
        {
            return Members(channel, null, limit);
        }

        public Task<ConversationMembersResponse> Members(string channel, string cursor, int? limit)
        {
            var dict = new Dictionary<string, string> { { "channel", channel } };
            if (!string.IsNullOrWhiteSpace(cursor))
            {
                dict.Add("cursor", cursor);
            }

            if (limit.HasValue)
            {
                dict.Add("limit", limit.Value.ToString());
            }

            return _client.MakeUrlEncodedCall<ConversationMembersResponse>("conversations.members", dict);
        }

        public Task<ConversationOpenResponse> Open(ConversationOpenRequest request)
        {
            return _client.MakeJsonCall<ConversationOpenRequest, ConversationOpenResponse>("conversations.open",
                request);
        }

        public Task<ChannelResponse> Rename(string channel, string name)
        {
            var dict = new Dictionary<string, string>
            {
                { "channel", channel },
                { "name", name }
            };

            return _client.MakeUrlEncodedCall<ChannelResponse>(
                "conversations.rename", dict);
        }

        public Task<ConversationRepliesResponse> Replies(ConversationRepliesRequest request)
        {
            return _client.MakeUrlEncodedCall<ConversationRepliesResponse>(
                "conversations.replies", request);
        }

        public Task<ConversationSetPurposeResponse> SetPurpose(string channel, string purpose)
        {
            var dict = new Dictionary<string, string>
            {
                { "channel", channel },
                { "purpose", purpose }
            };

            return _client.MakeUrlEncodedCall<ConversationSetPurposeResponse>(
                "conversations.setPurpose", dict);
        }

        public Task<ConversationSetTopicResponse> SetTopic(string channel, string topic)
        {
            var dict = new Dictionary<string, string>
            {
                { "channel", channel },
                { "topic", topic }
            };

            return _client.MakeUrlEncodedCall<ConversationSetTopicResponse>(
                "conversations.setTopic", dict);
        }

        public Task<WebApiResponse> Unarchive(string channel)
        {
            var dict = new Dictionary<string, string>
            {
                { "channel", channel }
            };

            return _client.MakeUrlEncodedCall(
                "conversations.unarchive", dict);
        }

        public Task<InviteSharedResponse> InviteShared(InviteSharedRequest request)
        {
            return _client.MakeJsonCall<InviteSharedRequest, InviteSharedResponse>("conversations.inviteShared",
                request);
        }


        public Task<AcceptSharedInviteResponse> AcceptSharedInvite(AcceptSharedInviteRequest request)
        {
            return _client.MakeJsonCall<AcceptSharedInviteRequest, AcceptSharedInviteResponse>("conversations.acceptSharedInvite",
                request);
        }
    }
}
