using System.Threading.Tasks;
using Slack.NetStandard.WebApi.Chat;

namespace Slack.NetStandard.WebApi
{
    public interface IChatApi
    {
        Task<PostMessageResponse> PostMessage(PostMessageRequest request);
    }
}