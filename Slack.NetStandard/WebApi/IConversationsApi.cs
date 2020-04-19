using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Conversations;

namespace Slack.NetStandard.WebApi
{
    public interface IConversationsApi
    {
        Task<WebApiResponse> Archive(string channel);
        Task<CloseConversationResponse> Close(string channel);

        Task<ChannelResponse> Create(string name, bool isPrivate = false);
        Task<ChannelResponse> Create(string name, string[] userIds, bool isPrivate = false);

        Task<ConversationHistoryResponse> History(ConversationHistoryRequest request);

        Task<ChannelResponse> Info(string channel, bool? includeLocale, bool? include_num_members);

        Task<ChannelResponse> Invite(string channel, params string[] users);
        Task<ChannelResponse> Join(string channel);

        Task<WebApiResponse> Kick(string channel, string user);

        Task<WebApiResponse> Leave(string channel);

        Task<ConversationListResponse> List(ConversationListRequest request);

        Task<ConversationMembersResponse> Members(string channel);
        Task<ConversationMembersResponse> Members(string channel, string cursor);
        Task<ConversationMembersResponse> Members(string channel, int limit);

        Task<ConversationMembersResponse> Members(string channel, string cursor, int? limit);

        Task<ConversationOpenResponse> Open(ConversationOpenRequest request);
    }
}
