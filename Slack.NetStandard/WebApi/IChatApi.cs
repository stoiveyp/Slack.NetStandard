using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Chat;

namespace Slack.NetStandard.WebApi
{
    public interface IChatApi
    {
        Task<PostMessageResponse> PostMessage(PostMessageRequest request);
        Task<MessageResponse> Delete(string channel, string timestamp, bool? asUser = null);

        Task<WebApiResponse> DeleteScheduledMessage(string channel, string scheduledMessageId, bool? asUser = null);

        Task<GetPermalinkResponse> GetPermalink(string channel, string timestamp);

        Task<MessageResponse> MeMessage(string channel, string action);
    }
}