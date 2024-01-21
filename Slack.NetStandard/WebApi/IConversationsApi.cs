using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Conversations;

namespace Slack.NetStandard.WebApi
{
    public interface IConversationsApi
    {
        Task<WebApiResponse> Archive(string channel);
        Task<CloseConversationResponse> Close(string channel);

        Task<ChannelResponse> Create(string name, bool isPrivate = false, string teamId = null);
        Task<ChannelResponse> Create(string name, string[] userIds, bool isPrivate = false, string teamId = null);

        Task<ConversationHistoryResponse> History(ConversationHistoryRequest request);

        Task<ChannelResponse> Info(string channel, bool? includeLocale, bool? include_num_members);

        Task<ChannelResponse> Invite(string channel, params string[] users);

        Task<ChannelResponse> Join(string channel);

        Task<WebApiResponse> Kick(string channel, string user);

        Task<WebApiResponse> Leave(string channel);

        Task<ChannelListResponse> List(ConversationListRequest request);

        Task<ConversationMembersResponse> Members(string channel);
        Task<ConversationMembersResponse> Members(string channel, string cursor);
        Task<ConversationMembersResponse> Members(string channel, int limit);

        Task<ConversationMembersResponse> Members(string channel, string cursor, int? limit);

        Task<ConversationOpenResponse> Open(ConversationOpenRequest request);

        Task<ChannelResponse> Rename(string channel, string name);
        Task<ConversationRepliesResponse> Replies(ConversationRepliesRequest request);
        Task<ConversationSetPurposeResponse> SetPurpose(string channel, string purpose);

        Task<ConversationSetTopicResponse> SetTopic(string channel, string topic);

        Task<WebApiResponse> Unarchive(string channel);

        Task<InviteSharedResponse> InviteShared(InviteSharedRequest request);
        Task<AcceptSharedInviteResponse> AcceptSharedInvite(AcceptSharedInviteRequest request);
        Task<WebApiResponse> ApproveSharedInvite(string inviteId, string teamId);
        Task<WebApiResponse> DeclineSharedInvite(string inviteId, string teamId);
        Task<WebApiResponse> DisconnectShared(string channelId, params string[] leavingTeamIds);

        Task<ListConnectInviteResponse> ListConnectInvites(int count);
        Task<ListConnectInviteResponse> ListConnectInvites(string cursorId = null, int? count = null);

        Task<ListConnectInviteResponse> ListConnectInvitesForTeam(string teamId, int count);
        Task<ListConnectInviteResponse> ListConnectInvitesForTeam(string teamId, string cursorId = null, int? count = null);
    }
}
