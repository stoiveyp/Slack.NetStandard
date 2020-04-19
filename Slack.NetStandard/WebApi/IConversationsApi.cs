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
    }
}
