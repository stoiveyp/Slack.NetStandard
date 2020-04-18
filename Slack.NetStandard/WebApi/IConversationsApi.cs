using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Conversations;

namespace Slack.NetStandard.WebApi
{
    public interface IConversationsApi
    {
        Task<WebApiResponse> Archive(string channel);
        Task<CloseConversationResponse> Close(string channel);

        Task<CreateConversationResponse> Create(string name, bool isPrivate = false);
        Task<CreateConversationResponse> Create(string name, string[] userIds, bool isPrivate = false);
    }
}
